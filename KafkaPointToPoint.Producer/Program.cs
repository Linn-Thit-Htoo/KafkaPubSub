using Confluent.Kafka;

namespace KafkaPointToPoint.Producer
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:29092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            Console.WriteLine("Producer started...");

            for (int i = 0; i < 10; i++)
            {
                var deliveryReport = await producer.ProduceAsync("test-topic",
                    new Message<Null, string> { Value = $"Message {i}" });

                Console.WriteLine($"Produced message: {deliveryReport.Value}");
            }
        }
    }
}
