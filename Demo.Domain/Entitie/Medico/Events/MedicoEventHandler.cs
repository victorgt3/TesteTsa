using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Demo.Domain.Entitie.Medico.Events.Medico;
using Demo.Domain.Interfaces;
using Demo.Domain.Entitie.Especialidade.Commands.Especialidade;

namespace Demo.Domain.Entitie.Medico.Events
{
    public class MedicoEventHandler :
        INotificationHandler<MedicoRegistradoEvent>,
        INotificationHandler<MedicoExcluidoEvent>
    {
        private readonly IMediatorHandler _mediator;
        public MedicoEventHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }
        public Task Handle(MedicoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            foreach(var item in notification.Especialidades)
            {
                var especialidadeCommand = new  RegistraEspecialidadeCommand(notification.Id, item);

                _mediator.EnviarComando(especialidadeCommand);
            }
            return Task.CompletedTask;
        }

        public Task Handle(MedicoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
