using AutoMapper;
using Demo.AutoMapper.ViewModels;
using Demo.Domain.Entitie.Medico;
using Demo.Domain.Entitie.Medico.Commands.Medico;

namespace Demo.AutoMapper.Maps
{
    public class MedicoMappingProfile : Profile
    {
        public MedicoMappingProfile()
        {
            CreateMap<Medico, MedicoViewModel>();

            CreateMap<MedicoViewModel, PostMedicoViewModel>();

            CreateMap<PostMedicoViewModel, RegistraMedicoCommand>()
            .ConstructUsing(c => new RegistraMedicoCommand(c.Id, c.Nome, c.CPF, c.Crm));

            CreateMap<MedicoViewModel, ExcluirMedicoCommand>()
           .ConstructUsing(c => new ExcluirMedicoCommand(c.Id));
        }
    }
}
