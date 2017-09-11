using System.Collections.Generic;

using MediatR;

namespace CaliCare.Infrastructure.Extensions
{
   public static class MediatorExtensions
   {
      public static void SendSync(this IMediator mediator, IEnumerable<IRequest> commands)
      {
         foreach (var command in commands)
            mediator.SendSync(command);
      }

      public static void SendSync(this IMediator mediator, IRequest command)
      {
         mediator.Send(command).Wait();
      }

      public static TResult SendSync<TResult>(this IMediator mediator, IRequest<TResult> query)
      {
         return mediator.Send(query).Result;
      }
   }
}
