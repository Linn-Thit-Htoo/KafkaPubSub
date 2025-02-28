using Confluent.Kafka;

namespace KafkaPointToPoint.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:29092",
                GroupId = "test-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("test-topic");

            Console.WriteLine("Consumer started...");
            while (true)
            {
                var consumeResult = consumer.Consume(CancellationToken.None);
                Console.WriteLine($"Received message: {consumeResult.Value}");
            }
        }
    }
}
