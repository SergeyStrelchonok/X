using XSolution.API.Services;
using XSolution.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IRegistrationService, RegistrationService>();


var app = builder.Build();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
