using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Demo.Domain.Core.Notifications;
using Demo.Domain.Entitie.Medico.Commands.Medico;
using Demo.Domain.Entitie.Medico.Events.Medico;
using Demo.Domain.Entitie.Medico.Repository;
using Demo.Domain.Handlers;
using Demo.Domain.Interfaces;
using Demo.Domain.Entitie.Especialidade.Repository;

namespace Demo.Domain.Entitie.Medico.Commands
{
    public class MedicoCommandHandler : CommandHandler,
        IRequestHandler<RegistraMedicoCommand, bool>,
        IRequestHandler<ExcluirMedicoCommand, bool>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMediatorHandler _mediator;
        public MedicoCommandHandler(IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, IMedicoRepository medicoRepository,
            IEspecialidadeRepository especialidadeRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
        }
        public Task<bool> Handle(RegistraMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = new Domain.Entitie.Medico.Medico(request.Id, request.Nome, request.CPF, request.Crm, request.Especialidades.FirstOrDefault());

            if (!medico.EhValido())
            {
                NotificarValidacoesErro(medico.ValidationResult);
                return Task.FromResult(false);
            }

            _medicoRepository.Adicionar(medico);

            if (Commit())
            {
                _mediator.PublicarEvento(new MedicoRegistradoEvent(medico.Id, medico.Nome, medico.CPF, medico.Crm, request.Especialidades));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = _medicoRepository.GetById(request.Id);

            foreach (var esp in medico.Result.Especialidade)
            {
                _especialidadeRepository.Remover(esp.Id);
            }
            _medicoRepository.Remover(request.Id);

            if (Commit())
            {
                _mediator.PublicarEvento(new MedicoExcluidoEvent(request.Id));
            }

            return Task.FromResult(true);
        }
    }
}
