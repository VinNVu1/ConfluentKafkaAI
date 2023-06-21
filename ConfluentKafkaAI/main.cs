using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConfluentKafkaAI
{
    class main
    {
        static async Task Main(string[] args)
        {
            var producer = new KafkaProducer("localhost:9092");
            await producer.ProduceMessage("my-fucking-topic", "Fuck you kafka");

            var consumer = new KafkaConsumer("localhost:9092", "bruh-bruh-bruh");
            consumer.ConsumeMessages("my-fucking-topic");
        }
    }
}
