
using System;

namespace TestNinja.Fundamentals
{
    
    public class ErrorLogger
    {
        public string LastError { get; set; }
        private Guid _errorID;

        public event EventHandler<Guid> ErrorLogged; 
        

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write the log to a storage
            // ...

            
            _errorID = Guid.NewGuid();

            //Section 3 - Tutorial 8 - Testing Private Methods:
            //Moving this to Protected Implementation Method.

            //ErrorLogged?.Invoke(this, Guid.NewGuid());

            //Task 2 - Return Event Raising to Log
            //Task 1 - Making Error ID Private & not passed in OnErrorLogged()
            //ErrorLogged?.Invoke(this, _errorID);

            //Task 3 - Making Event Raising Protected & Passing Guid Again
            OnErrorLogged(Guid.NewGuid());
        }

        //Task 3 - Making Event Raising Protected & Passing Guid Again
        public virtual void OnErrorLogged(Guid guid)
        {
            ErrorLogged?.Invoke(this, guid);
        }


        
        //Task 2 - Remove Call to Invoke,bring it all back to Log Method
        //Task 1 - Making Error ID Private & not passed in OnErrorLogged()
        //public virtual void OnErrorLogged(Guid _errorID)
        //{
        //    ErrorLogged?.Invoke(this, guid);
        //}
    }
}