using Confluent.Kafka;

namespace KafkaPointToPoint.Consumer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:29092",
                GroupId = "test-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("test-topic");

            Console.WriteLine("Consumer 2 started...");
            while (true)
            {
                var consumeResult = consumer.Consume(CancellationToken.None);
                Console.WriteLine($"Received message: {consumeResult.Value}");
            }
        }
    }
}
