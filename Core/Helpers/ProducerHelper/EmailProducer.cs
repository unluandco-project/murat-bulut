using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.ProducerHelper
{
    public class EmailProducer
    {
        public static void SendMail(object user)
        {
            //RabbitMQ bağlantısı için
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            //Channel yaratmak için
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                //Kuyruk oluşturma
                channel.QueueDeclare(queue: "QueueNameEmail",
                    durable: false, //Data fiziksel olarak mı yoksa memoryde mi tutulsun
                    exclusive: false, //Başka connectionlarda bu kuyruğa ulaşabilsin mi
                    autoDelete: false, //Eğer kuyruktaki son mesaj ulaştığında kuyruğun silinmesini istiyorsak kullanılır.
                    arguments: null);//Exchangelere verilecek olan parametreler tanımlamak için kullanılır.

                string message = JsonConvert.SerializeObject(user);
                var body = Encoding.UTF8.GetBytes(message);

                //Queue ya atmak için kullanılır.
                channel.BasicPublish(exchange: "",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: "QueueNameEmail", //Hangi queue ya atanacak.
                    body: body);//Mesajın içeriği
            }
        }

    }
}
