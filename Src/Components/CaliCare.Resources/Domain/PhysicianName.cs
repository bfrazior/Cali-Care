namespace CaliCare.Resources.Domain
{
   public class PhysicianName
   {
      public string FirstName { get; }
      public string MiddleName { get; }
      public string LastName { get; }
      public string UserName { get; }

      internal PhysicianName(string firstName, string middleName, string lastName, string userName)
      {
         FirstName = firstName;
         MiddleName = middleName;
         LastName = lastName;
         UserName = userName;
      }
   }
}
