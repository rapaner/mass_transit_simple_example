﻿using MassTransit;
using Newtonsoft.Json;
using SharedModels;

namespace Consumer
{
    class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");
        }
    }
}