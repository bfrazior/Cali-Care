namespace CaliCare.Patients.Domain
{
   public class PatientName
   {
      public string FirstName { get; }
      public string MiddleName { get; }
      public string LastName { get; }
      public string PreferredName { get; }

      public PatientName(string firstName, string middleName, string lastName, string preferredName)
      {
         FirstName = firstName;
         MiddleName = middleName;
         LastName = lastName;
         PreferredName = preferredName;
      }
   }
}
