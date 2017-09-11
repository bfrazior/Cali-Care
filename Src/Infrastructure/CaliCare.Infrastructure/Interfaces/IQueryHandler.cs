using MediatR;

namespace CaliCare.Infrastructure.Interfaces
{
   public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
      where TQuery : IQuery<TResult>
   {
   }
}
