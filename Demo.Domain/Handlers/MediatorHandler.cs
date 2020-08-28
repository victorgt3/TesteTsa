using Demo.Domain.Core.Commands;
using Demo.Domain.Core.Events;
using Demo.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace Demo.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;

        }

        public Task EnviarComando<T>(T comando) where T : Command
        {
            return _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
