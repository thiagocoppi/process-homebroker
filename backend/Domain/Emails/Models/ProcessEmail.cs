namespace Domain.Emails.Models
{
    public class ProcessEmail
    {
        public ProcessEmail(string destinatario, bool ehHtml, string texto, string titulo)
        {
            Destinatario = destinatario;
            EhHtml = ehHtml;
            Texto = texto;
            Titulo = titulo;
        }

        public string Destinatario { get; private set; }
        public bool EhHtml { get; private set; }
        public bool Enviado { get; set; }
        public string MensagemErro { get; set; }
        public string Texto { get; private set; }
        public string Titulo { get; private set; }
    }
}