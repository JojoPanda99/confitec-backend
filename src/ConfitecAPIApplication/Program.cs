using ConfitecAPIApplication.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependencyInjection();

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.AddControllers();
builder.Services.ConfigurePolicies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.UseHttpsRedirection();
app.UsePolicies();

app.UseAuthorization();

app.MapControllers();

app.Run();