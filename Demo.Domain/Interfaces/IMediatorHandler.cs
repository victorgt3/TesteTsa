using Demo.Domain.Core.Commands;
using Demo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Demo.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
