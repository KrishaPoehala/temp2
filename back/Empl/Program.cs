using Empl.Application.Interfaces;
using Empl.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssemblyContaining(typeof(Empl.Application.AssemblyReference))
);

builder.Services.AddDbContext<EmployeeContext>(x =>
x.UseNpgsql(builder.Configuration.GetConnectionString("BooksDb"),
opt => opt.MigrationsAssembly(typeof(EmployeeContext).Assembly.GetName().Name))
);

builder.Services.AddScoped<IApplicationDbContext>(provider => 
    provider.GetRequiredService<EmployeeContext>());
builder.Services.AddAutoMapper(typeof(Empl.Application.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin()
                    .WithOrigins(new string[] { "http://localhost:4200", "https://localhost:4200" })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
app.MapControllers();

InitializeDb(app);

app.Run();

void InitializeDb(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
    context.Database.Migrate();
}
