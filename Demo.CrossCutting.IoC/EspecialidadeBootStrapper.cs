using Demo.Dal.Repository;
using Demo.Domain.Entitie.Especialidade.Commands;
using Demo.Domain.Entitie.Especialidade.Commands.Especialidade;
using Demo.Domain.Entitie.Especialidade.Events;
using Demo.Domain.Entitie.Especialidade.Events.Especialidade;
using Demo.Domain.Entitie.Especialidade.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.CrossCutting.IoC
{
    public class EspecialidadeBootStrapper
    {
        public static void Register(IServiceCollection services)
        {

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistraEspecialidadeCommand, bool>, EspecialidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEspecialidadeCommand, bool>, EspecialidadeCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<EspecialidadeRegistradoEvent>, EspecialidadeEventHandler>();
            services.AddScoped<INotificationHandler<EspecialidadeExcluidoEvent>, EspecialidadeEventHandler>();

            // Infra - Data
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        }
    }
}
