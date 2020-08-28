using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Demo.Domain.Entitie.Especialidade.Events.Especialidade;

namespace Demo.Domain.Entitie.Especialidade.Events
{
    public class EspecialidadeEventHandler :
        INotificationHandler<EspecialidadeRegistradoEvent>,
        INotificationHandler<EspecialidadeExcluidoEvent>
    {
        public Task Handle(EspecialidadeRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(EspecialidadeExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
