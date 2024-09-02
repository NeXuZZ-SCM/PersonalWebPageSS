using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PWP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {

        static bool mailSent = false;
        // GET: api/<MailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };


            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("nexuzz@outlook.com",
               "Jane " + (char)0xD8 + " Clayton",
            System.Text.Encoding.UTF8);


            client.EnableSsl = true;
            client.Host = "smtp-mail.outlook.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("nexuzz@outlook.com", "Cracker214");


            // Set destinations for the email message.
            MailAddress to = new MailAddress("nexuzz@outlook.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            //string userState = "test message1";
            //client.SendAsync(message, userState);



            client.SendCompleted += (s, e) => {
                client.Dispose();
                message.Dispose();
            };
            client.SendAsync(message, null);



            //Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            //string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            //if (mailSent == false)/*answer.StartsWith("c") && */
            //{
            //    client.SendAsyncCancel();
            //}
            // Clean up.
            //message.Dispose();
            //Console.WriteLine("Goodbye.");

            return new string[] { "value1", "value2" };
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                //Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                //Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                //Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }



























        // GET api/<MailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MailController>
        [HttpPost]
        public void Post([FromBody] Modelo modelo)
        {
            //return new string[] { "value1", "value2" };


            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("nexuzz@outlook.com",
               "WEB PERSONAL " + (char)0xD8 + " CONTACTO LABORAL",
            System.Text.Encoding.UTF8);


            client.EnableSsl = true;
            client.Host = "smtp-mail.outlook.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("nexuzz@outlook.com", "Cracker214");


            // Set destinations for the email message.
            MailAddress to = new MailAddress("nexuzz@outlook.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = $"hola soy {modelo.Nombre} mi correo es {modelo.Email} Mensaje: {modelo.Mensaje} || De forma : {modelo.TipoDeContacto}";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            //string userState = "test message1";
            //client.SendAsync(message, userState);



            client.SendCompleted += (s, e) => {
                client.Dispose();
                message.Dispose();
            };
            client.SendAsync(message, null);



            //Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            //string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            //if (mailSent == false)/*answer.StartsWith("c") && */
            //{
            //    client.SendAsyncCancel();
            //}
            // Clean up.
            //message.Dispose();
            //Console.WriteLine("Goodbye.");

            //return new string[] { "value1", "value2" };
        }

        // PUT api/<MailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class Modelo
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Mensaje { get; set; }
        public string TipoDeContacto { get; set; }

    };
}
