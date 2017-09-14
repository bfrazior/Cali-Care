using System;
using System.Collections.Generic;
using System.Linq;

using MediatR;

using CaliCare.Infrastructure.Extensions;
using CaliCare.Schedule.Application.Queries;
using CaliCare.Schedule.Domain;
using CaliCare.Schedule.Application;

namespace CaliCare.Schedule.Services
{
   public class AppointmentSlotService : IAppointmentSlotService
   {
      private readonly IMediator _mediator;

      public AppointmentSlotService(IMediator mediator)
      {
         _mediator = mediator;
      }

      public Tuple<ScheduleSlot[], Guid, AppointmentStaff> GetNextAvailableAppointmentSlots(
         DateTime searchStartDate,
         int searchStartSlot,
         AppointmentStaff[] staffSearch,
         Guid[] roomSearch,
         int slotsToFill)
      {
         var scheduleDaySlots = _mediator.SendSync(new GetScheduleDayQuery() { Date = searchStartDate.Date })
            .Slots
            .Select(x => ScheduleConverter.ConvertToDomain(x))
            .ToArray();

         for (var slotNumber = searchStartSlot; slotNumber <= 31; slotNumber++)
         {
            Guid? availRoom = null;
            foreach (var room in roomSearch)
            {
               if (IsRoomAvailable(room, scheduleDaySlots, searchStartSlot, slotsToFill))
               {
                  availRoom = room;
                  break;
               }
            }
            if (!availRoom.HasValue)
               continue;

            AppointmentStaff availStaff = null;
            foreach (var staff in staffSearch)
            {
               if (IsStaffAvailable(staff, scheduleDaySlots, searchStartSlot, slotsToFill))
               {
                  availStaff = staff;
                  break;
               }
            }
            if (availStaff == null)
               continue;

            var availSlots = new List<ScheduleSlot>();
            for (var availSlotNumber = slotNumber; availSlotNumber > slotNumber - slotsToFill; availSlotNumber--)
               availSlots.Add(scheduleDaySlots[slotNumber]);

            return new Tuple<ScheduleSlot[], Guid, AppointmentStaff>(availSlots.ToArray(), availRoom.Value, availStaff);
         }

         return GetNextAvailableAppointmentSlots(searchStartDate.AddDays(1), 0, staffSearch, roomSearch, slotsToFill);
      }


      private bool IsRoomAvailable(Guid roomId, ScheduleSlot[] slots, int searchStartSlot, int slotsToFill)
      {
         for (var slotNumber = searchStartSlot; slotNumber < searchStartSlot + slotsToFill; slotNumber++)
         {
            if (slots[slotNumber].Appointments != null)
            {
               foreach (var appointmentId in slots[slotNumber].Appointments)
               {
                  var appointment = _mediator.SendSync(new GetAppointmentQuery() { Id = appointmentId });
                  if (appointment.RoomId == roomId)
                     return false;
               }
            }
         }

         return true;
      }

      private bool IsStaffAvailable(AppointmentStaff staff, ScheduleSlot[] slots, int searchStartSlot, int slotsToFill)
      {
         for (var slotNumber = searchStartSlot; slotNumber < searchStartSlot + slotsToFill; slotNumber++)
         {
            if (slots[slotNumber].Appointments != null)
            {
               foreach (var appointmentId in slots[slotNumber].Appointments)
               {
                  var appointment = _mediator.SendSync(new GetAppointmentQuery() { Id = appointmentId });
                  if (appointment.Staff.AppointmentStaffId == staff.AppointmentStaffId)
                     return false;
               }
            }
         }

         return true;
      }
   }
}
