using MassTransit;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.AddRequestClient<GetOrder>(new Uri("exchange:order"));

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "eshop-packets");
        cfg.ConfigureEndpoints(context);
    });
});
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();