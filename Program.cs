var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular default port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(); // 👈 Important!

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
