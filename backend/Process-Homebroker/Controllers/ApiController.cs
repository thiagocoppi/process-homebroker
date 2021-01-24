using Application.Commands.Ordens.Cadastrar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Process_Homebroker.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected UsuarioCommand ObterUsuarioAutenticacao()
        {
            var nome = User.Claims.First(r => r.Type == "Nome");
            var cpf = User.Claims.First(r => r.Type == "Cpf");
            var id = User.Claims.First(r => r.Type == "Id");

            return new UsuarioCommand()
            {
                Cpf = cpf.Value,
                Nome = nome.Value,
                Id = id.Value
            };
        }
    }
}