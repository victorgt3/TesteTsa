using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Demo.Domain.Core.Notifications;
using Demo.Domain.Entitie.Especialidade.Commands.Especialidade;
using Demo.Domain.Entitie.Especialidade.Events.Especialidade;
using Demo.Domain.Entitie.Especialidade.Repository;
using Demo.Domain.Handlers;
using Demo.Domain.Interfaces;

namespace Demo.Domain.Entitie.Especialidade.Commands
{
    public class EspecialidadeCommandHandler : CommandHandler,
        IRequestHandler<RegistraEspecialidadeCommand, bool>,
        IRequestHandler<ExcluirEspecialidadeCommand, bool>
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMediatorHandler _mediator;
        public EspecialidadeCommandHandler(IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, IEspecialidadeRepository especialidadeRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _especialidadeRepository = especialidadeRepository;
        }

        public Task<bool> Handle(RegistraEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            var especialidade = new Domain.Entitie.Especialidade.Especialidade(request.MedicoId, request.Descricao);

            if (!especialidade.EhValido())
            {
                NotificarValidacoesErro(especialidade.ValidationResult);
                return Task.FromResult(false);
            }

            _especialidadeRepository.Adicionar(especialidade);

            if (Commit())
            {
                _mediator.PublicarEvento(new EspecialidadeRegistradoEvent(especialidade.MedicoId, especialidade.Descricao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            _especialidadeRepository.Remover(request.Id);

            if (Commit())
            {
                _mediator.PublicarEvento(new EspecialidadeExcluidoEvent(request.Id));
            }

            return Task.FromResult(true);
        }
    }
}
