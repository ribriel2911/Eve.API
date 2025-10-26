using API;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "AllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
// Add services to the container.

builder.Services.AddDependencies(builder.Configuration, builder.Environment.IsProduction());

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
