using MediatR;

namespace CaliCare.Infrastructure.Interfaces
{
   public interface IQuery<TResult> : IRequest<TResult>
   {
   }
}
