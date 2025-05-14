using NubaHotel.BookingSystem.Api;
using NubaHotel.BookingSystem.Api.Middleware;
using NubaHotel.BookingSystem.Application;
using NubaHotel.BookingSystem.Infra.External;
using NubaHotel.BookingSystem.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddApi(builder.Configuration)
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddExternal(builder.Configuration);

var app = builder.Build();

// Middlewares
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseCors(policyBuilder =>
{
    policyBuilder.WithOrigins("https://localhost:44310")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NubaHotel.Booking.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NubaHotel.Booking.Api v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
    
app.UseAuthorization();

app.MapControllers();

app.Run();
