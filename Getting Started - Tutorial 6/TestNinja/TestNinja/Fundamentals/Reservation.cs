namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        //Task 1 - Business Logic, only Admin or User/Owner of reservation can cancel.
        //Step 1 - Create Unit Test Project within Solution
        //Step 2 - Rename Class & Methods
        //Step 3 - Define the Scenarios
        //Step 4 - Writing the Test:
        //Step 5 - Run the Tests
        //Step 6 - Complete the other Scenarios
        public bool CanBeCancelledBy(User user)
        {
            if (user.IsAdmin)
                return true;
            if (MadeBy == user)
                return true;

            return false;

            //return (user.IsAdmin || MadeBy == user);
        }
        
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}