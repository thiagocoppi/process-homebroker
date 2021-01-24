using Domain.Emails;
using Domain.Emails.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Email
{
    public sealed class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ProcessEmail EnviarEmail(ProcessEmail emailEnviar)
        {
            var smtpEnviar = _configuration.GetValue<string>("Email:Servidor");
            var emailEnvio = _configuration.GetValue<string>("Email:EmailEnvio");
            var senhaEmail = _configuration.GetValue<string>("Email:SenhaGmail");
            var porta = _configuration.GetValue<int>("Email:Porta");

            var email = new MailMessage
            {
                From = new MailAddress(emailEnvio)
            };
            email.To.Add(emailEnviar.Destinatario);
            email.Subject = emailEnviar.Titulo;
            email.Body = emailEnviar.Texto;
            email.IsBodyHtml = true;

            using var client =
                new SmtpClient
                {
                    Host = smtpEnviar,
                    Port = porta,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailEnvio, senhaEmail)
                };

            try
            {
                client.Send(email);
            }
            catch (Exception e)
            {
                emailEnviar.Enviado = false;
                emailEnviar.MensagemErro = e.Message;
                throw;
            }

            emailEnviar.Enviado = true;

            return emailEnviar;
        }
    }
}