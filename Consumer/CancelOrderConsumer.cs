using MassTransit;
using Newtonsoft.Json;
using SharedModels;

namespace Consumer
{
    class CancelOrderConsumer : IConsumer<CancelOrder>
    {
        public async Task Consume(ConsumeContext<CancelOrder> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"Cancel order message: {jsonMessage}");
        }
    }
}