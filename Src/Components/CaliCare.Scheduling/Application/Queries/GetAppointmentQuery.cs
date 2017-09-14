using System;

using CaliCare.Infrastructure.Interfaces;
using CaliCare.Schedule.Ports.DataTransferObjects;

namespace CaliCare.Schedule.Application.Queries
{
   public class GetAppointmentQuery : IQuery<AppointmentDto>
   {
      public Guid Id { get; set; }
   }
}
