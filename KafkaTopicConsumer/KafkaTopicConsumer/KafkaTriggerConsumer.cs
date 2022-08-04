using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KafkaTopicConsumer
{
    public class KafkaTriggerConsumer
    {
        // KafkaTrigger sample 
        // Consume the message from "topic" on the LocalBroker.
        // Add `BrokerList` and `KafkaPassword` to the local.settings.json
        // For EventHubs
        // "BrokerList": "{EVENT_HUBS_NAMESPACE}.servicebus.windows.net:9093"
        // "KafkaPassword":"{EVENT_HUBS_CONNECTION_STRING}
        [FunctionName("KafkaTriggerConsumer")]
        public void Run(
            [KafkaTrigger("BrokerList",
                          "purchases",
                          Username = "ConfluentCloudUserName",
                          Password = "ConfluentCloudPassword",
                          Protocol = BrokerProtocol.SaslSsl,
                          AuthenticationMode = BrokerAuthenticationMode.Plain,
                          ConsumerGroup = "$Default")] KafkaEventData<string>[] events,
            ILogger log)
        {
            foreach(KafkaEventData<string> eventData in events)
            {
                var order = JsonConvert.DeserializeObject<Order>(eventData.Value);

                log.LogInformation($"New order from Kafka:\n Id:{order.Id}\n Items:\n");
                
                foreach(string item in order.Items)
                {
                    log.LogInformation($"\t{item}\n");
                }
            }
        }
    }
}
