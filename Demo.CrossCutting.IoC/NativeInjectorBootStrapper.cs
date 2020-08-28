using Microsoft.Extensions.DependencyInjection;

namespace Demo.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            CoreBootStrapper.Register(services);

            MedicoBootStrapper.Register(services);

            EspecialidadeBootStrapper.Register(services);
        }
    }
}
