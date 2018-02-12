
using System;

namespace TestNinja.Fundamentals
{
    //Section 3 - Tutorial 5 - Testing Void Methods:
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            //Changing State of LastError
            //To Test this, we test the State of LastError
            LastError = error; 
            
            // Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}