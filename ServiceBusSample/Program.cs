using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusSample
{
    internal class Program
    {
        private readonly QueueClient _queueClient;
        private int iterator = 0;

        private const string CONNECTION = "{ConnectionString}";
        private const string QUEUE_NAME = "{QueueName}";

        public Program()
        {
            _queueClient = new QueueClient(CONNECTION, QUEUE_NAME);
        }

        public async Task SendMessage()
        {
            string body = $"Message body {iterator++}";
            var message = new Message(Encoding.UTF8.GetBytes(body));

            await _queueClient.SendAsync(message);
        }

        public static async Task Main(string[] args)
        {
            var program = new Program();
            Console.WriteLine("Producent program");
            Console.WriteLine("Sending messages to consumer");
            while (true)
            {
                await program.SendMessage();
                await Task.Delay(1000);
            }
        }
    }
}
