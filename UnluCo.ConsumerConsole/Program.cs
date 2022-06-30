using System;
using System.Text;
using UnluCo.ConsumerConsole.Consumers;

namespace UnluCo.ConsumerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start mail consumer
            EmailConsumer.SendMail();
        }
    }
}
