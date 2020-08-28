using AutoMapper;
using Demo.AutoMapper.ViewModels;
using Demo.Domain.Entitie.Especialidade;
using Demo.Domain.Entitie.Especialidade.Commands.Especialidade;

namespace Demo.AutoMapper.Maps
{
    public class EspecialidadeMappingProfile : Profile
    {
        public EspecialidadeMappingProfile()
        {
            CreateMap<Especialidade, EspecialidadeViewModel>();

            CreateMap<EspecialidadeViewModel, RegistraEspecialidadeCommand>()
          .ConstructUsing(c => new RegistraEspecialidadeCommand(c.MedicoId, c.Descricao));

            CreateMap<EspecialidadeViewModel, ExcluirEspecialidadeCommand>()
           .ConstructUsing(c => new ExcluirEspecialidadeCommand(c.Id));
        }
    }
}
