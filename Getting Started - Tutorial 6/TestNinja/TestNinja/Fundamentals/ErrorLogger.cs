
using System;

namespace TestNinja.Fundamentals
{
    //Section 3 - Tutorial 6 - Testing Exceptions:
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        

        public void Log(string error)
        {
            //Test Cases:
            //1 - Null
            //2 - Empty String
            //3 - String with WhiteSpae

            //Sanity Check Comment out these 2 lines
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error; 
            
            // Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}