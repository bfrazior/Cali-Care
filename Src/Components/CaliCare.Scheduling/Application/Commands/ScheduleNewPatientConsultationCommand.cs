using System;


namespace CaliCare.Schedule.Application.Commands
{
   public class ScheduleNewPatientConsultationCommand : CreateAppointmentCommand
   {
      public Guid DepartmentId { get; set; }
   }
}
