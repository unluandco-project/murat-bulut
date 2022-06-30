using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Entities.Concrete;

namespace UnluCo.ConsumerConsole.Consumers
{
    public class EmailConsumer
    {
        public static void SendMail()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                //TODO: Received methoduyla gelen dataları yakalayıp işlem yapacağımız için EventingBasicConsumer classından nesne alıyoruz.
                var consumer = new EventingBasicConsumer(channel);
                //TODO: Yeni data geldiğinde bu event otomatik tetikleniyor.
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.Span;//TODO: Kuyruktaki içerik bilgisi.
                    var message = Encoding.UTF8.GetString(body);//TODO: Gelen bodyi stringe çeviriyoruz.
                    User user = JsonConvert.DeserializeObject<User>(message); //TODO: Mesajdan dönen veriyi classa çeviriyoruz.
                    try
                    {
                        var email = new MimeMessage();
                        email.From.Add(MailboxAddress.Parse("todoapptr@gmail.com"));
                        email.To.Add(MailboxAddress.Parse(user.Email));
                        email.Subject = (user.isActive ? "Ünlü&Co Store Hesap Onayı" : "Ünlü&Co Store Hesap Askıya Alındı");
                        email.Body = new TextPart(TextFormat.Html)
                        {
                            Text = (
                                  user.isActive ? "Merhaba " + user.Name + " " + user.Surname + "," + "<p>Hesabınız başarıyla oluşturuldu.</p> <p>Saygılarımızla,</p> <p><b>Ünlü&Co Store Müşteri Deneyim Ekibi</b></p>"
                                                : "Merhaba " + user.Name + " " + user.Surname + "," + "<p>Hesabınız askıya alındı, lütfen destek ekibimizle iletişime geçiniz.</p> <p>Saygılarımızla,</p> <p><b>Ünlü&Co Store Müşteri Deneyim Ekibi</b></p>"
                                 )

                        };

                        // send email
                        using var smtp = new SmtpClient();
                        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        smtp.Authenticate("todoapptr@gmail.com", "ygtcjhwkcgtfbqwd");
                        smtp.Send(email);
                        smtp.Disconnect(true);

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("HATA: Kullanıcıya mail gönderilemedi, tekrar deneniyor...");

                    }

                };
                channel.BasicConsume(queue: "QueueNameEmail", //TODO: Consume edilecek kuyruk ismi
                        autoAck: true, //TODO: Kuyruk ismi doğrulansın mı
                        consumer: consumer); //TODO: Hangi consumer kullanılacak.

                Console.WriteLine("Mail kuyruğuna bağlantı başarılı. Dinleniyor...");
                Console.ReadKey();
            }
        }
    }
}
