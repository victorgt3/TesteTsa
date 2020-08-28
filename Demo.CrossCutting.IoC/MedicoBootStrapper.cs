using Demo.Dal.Repository;
using Demo.Domain.Entitie.Medico.Commands;
using Demo.Domain.Entitie.Medico.Commands.Medico;
using Demo.Domain.Entitie.Medico.Events;
using Demo.Domain.Entitie.Medico.Events.Medico;
using Demo.Domain.Entitie.Medico.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.CrossCutting.IoC
{
    public class MedicoBootStrapper
    {
        public static void Register(IServiceCollection services)
        {

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistraMedicoCommand, bool>, MedicoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirMedicoCommand, bool>, MedicoCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<MedicoRegistradoEvent>, MedicoEventHandler>();
            services.AddScoped<INotificationHandler<MedicoExcluidoEvent>, MedicoEventHandler>();

            // Infra - Data
            services.AddScoped<IMedicoRepository, MedicoRepository>();
        }
    }
}
