using Confluent.Kafka;
using System;
using System.Threading;

public class KafkaConsumer
{
    private readonly ConsumerConfig _config;

    public KafkaConsumer(string bootstrapServers, string groupId)
    {
        _config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }

    public void ConsumeMessages(string topic)
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();

        consumer.Subscribe(topic);

        try
        {
            while (true)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Received message: {consumeResult.Message.Value}");
            }
        }
        catch (OperationCanceledException)
        {
            // The consumer was stopped.
        }
        finally
        {
            consumer.Close();
        }
    }
}
