using System;
using System.Linq;
using System.Collections.Generic;

using CaliCare.Infrastructure.Interfaces;

namespace CaliCare.Schedule.Domain
{
   public class ScheduleDay : IAggregateRoot
   {
      public Guid Id { get; }
      public DateTime Date { get; }

      public ScheduleSlot[] Slots { get; private set; }

      public ScheduleDay(Guid id, DateTime date, ScheduleSlot[] slots)
      {
         Id = id;
         Date = date;
         Slots = slots;
      }

      public static ScheduleDay Create(DateTime date)
      {
         var defaultSlots = new List<ScheduleSlot>();
         for (var slotNumber = 0; slotNumber <= 31; slotNumber++)
            defaultSlots.Add(ScheduleSlot.Create(date.Date, slotNumber, null));

         return new ScheduleDay(Guid.NewGuid(), date.Date, defaultSlots.ToArray());
      }

      public void FillSlots(ScheduleSlot[] slots)
      {
         if (slots == null)
            throw new ArgumentNullException($"{nameof(slots)} cannot be undefiend.");

         var slotList = Slots.ToList();
         foreach (var slot in slots)
         {
            var foundSlot = slotList.Where(x => x.SlotNumber == slot.SlotNumber).SingleOrDefault();

            if (foundSlot == null)
               slotList.Add(slot);
            else
               foundSlot = slot;
         }

         Slots = slotList.ToArray();
      }
   }
}
