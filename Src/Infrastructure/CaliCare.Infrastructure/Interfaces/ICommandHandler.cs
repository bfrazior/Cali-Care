using MediatR;

namespace CaliCare.Infrastructure.Interfaces
{
   public interface ICommandHandler<T> : IRequestHandler<T>
      where T : ICommand
   {
   }
}
