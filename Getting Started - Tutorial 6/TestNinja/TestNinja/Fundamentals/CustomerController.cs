namespace TestNinja.Fundamentals
{
    //Section 3 - Tutorial 4 - Testing Return Types
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id == 0)
                return new NotFound();
            
            return new Ok();
        }        
    }
    

    public class ActionResult { }
    
    public class NotFound : ActionResult { }
 
    public class Ok : ActionResult { }
}