using Confluent.Kafka;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using Microsoft.Extensions.Options;
using System.Text;

namespace MessageAPI.Concretes
{
    public class KafkaClient : IKafkaClient
    {
        private IProducer<string, string> _producer;
        private readonly KafkaSettings _kafkaSettings;
        private static readonly Random rand = new Random();

        public KafkaClient(IOptions<KafkaSettings> kafkaSettings)
        {
            _kafkaSettings = kafkaSettings.Value;

            var config = new Dictionary<string, string>
            {
                {"bootstrap.servers", _kafkaSettings.BoostrapServer },
                {"security.protocol", _kafkaSettings.Protocol },
                {"sasl.mechanisms", _kafkaSettings.Mechanisms },
                {"sasl.username", _kafkaSettings.Username },
                {"sasl.password", _kafkaSettings.Password }
            };

            var producer = new ProducerBuilder<string, string>(config);

            _producer = producer.SetKeySerializer(Serializers.Utf8).SetValueSerializer(Serializers.Utf8).Build();
        }

        public async Task writeMessage(string message)
        {
            var dr = await _producer.ProduceAsync(_kafkaSettings.Topic, new Message<string, string>
            {
                Key = rand.Next(5).ToString(),
                Value = message
            });

            Console.WriteLine($"KAFKA => Delivered {dr.Value} to {_kafkaSettings.Topic}");
            return;
        }
    }
}
