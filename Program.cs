using CQRSMediatRExample.Behaviors;
using CQRSMediatRExample.Models;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//* Register MediatR
builder.Services
    .AddSingleton<FakeDataStore>()
    .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
    .AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
