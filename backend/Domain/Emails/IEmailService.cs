using Domain.Emails.Models;
using System.Threading.Tasks;

namespace Domain.Emails
{
    public interface IEmailService
    {
        ProcessEmail EnviarEmail(ProcessEmail emailEnviar);
    }
}