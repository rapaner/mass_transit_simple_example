using AutoBogus;
using MassTransit;
using SharedModels;

namespace Consumer
{
    class GetOrderRequestConsumer : IConsumer<GetOrder>
    {
        public async Task Consume(ConsumeContext<GetOrder> context)
        {
            var orderId = context.Message.OrderId;
            var productName = AutoFaker.Generate<string>();
            var price = AutoFaker.Generate<decimal>();
            var quantity = AutoFaker.Generate<int>();

            await context.RespondAsync<OrderResult>(new
            {
                OrderId = orderId,
                ProductName = productName,
                Price = price,
                Quantity = quantity
            });
        }
    }
}