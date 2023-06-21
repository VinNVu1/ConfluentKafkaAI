using Confluent.Kafka;
using System.Threading.Tasks;

public class KafkaProducer
{
    private readonly ProducerConfig _config;

    public KafkaProducer(string bootstrapServers)
    {
        _config = new ProducerConfig { BootstrapServers = bootstrapServers };
    }

    public async Task ProduceMessage(string topic, string message)
    {
        using var producer = new ProducerBuilder<Null, string>(_config).Build();

        var kafkaMessage = new Message<Null, string> { Value = message };
        var deliveryResult = await producer.ProduceAsync(topic, kafkaMessage);
        Console.WriteLine($"Delivered message to '{deliveryResult.TopicPartitionOffset}'");
    }
}

