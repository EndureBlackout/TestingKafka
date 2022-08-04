using MessageAPI.Interfaces;
using MessageAPI.Models;
using Newtonsoft.Json;

namespace MessageAPI.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IKafkaClient _kafkaClient;

        public OrderService(IKafkaClient kafkaClient)
        {
            _kafkaClient = kafkaClient;
        }

        public async Task<bool> SubmitOrder(Order order)
        {
            var stringOrder = JsonConvert.SerializeObject(order);

            try
            {
                await _kafkaClient.writeMessage(stringOrder);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Broken: {e.Message}");
                return false;
            }
        }
    }
}
