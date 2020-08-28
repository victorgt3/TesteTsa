using AutoMapper;
using Demo.AutoMapper.Maps;

namespace Demo.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddMemberConfiguration();
                ps.AddProfile(new MedicoMappingProfile());
                ps.AddProfile(new EspecialidadeMappingProfile());
            }); 
        }
    }
}
