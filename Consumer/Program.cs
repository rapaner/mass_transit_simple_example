// See https://aka.ms/new-console-template for more information
using Consumer;
using MassTransit;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GetOrderRequestConsumer>()
        .Endpoint(e => e.Name = "order");

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "eshop-packets");

        cfg.ReceiveEndpoint("order-created-event", e =>
        {
            e.Consumer<OrderCreatedConsumer>();
        });

        cfg.ReceiveEndpoint("order-service", e =>
        {
            e.Consumer<CancelOrderConsumer>();
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();
app.Run();