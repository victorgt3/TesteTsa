using Demo.AutoMapper;
using Demo.Dal.Context;
using Demo.Dal.UoW;
using Demo.Domain.Core.Notifications;
using Demo.Domain.Handlers;
using Demo.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.CrossCutting.IoC
{
    public class CoreBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BrtContext>();
        }
    }
}
