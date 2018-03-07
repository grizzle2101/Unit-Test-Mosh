using System.Data.Entity;

namespace TestNinja.Mocking
{
    //Section 6 - Tutorial 7 - Empployee Controller.
    //This is a Sample of an ASP.NET MVC Application.
    //Test 1 - This Returns Correct Result.
    //Test 2 - Employee Deleted from Database.
    //Test 3 - Make sure Correct Employee Details sent to Mock.

    public class EmployeeController
    {
        //private EmployeeContext _db;
        private IEmployeeStorage _employeeStorage;

        public EmployeeController(IEmployeeStorage employeeStorage = null)
        {
            //_db = new EmployeeContext();
            _employeeStorage = employeeStorage ?? new EmployeeStorage();
        }


        //Task 3 - Refactor
        public ActionResult DeleteEmployee(int id)
        {
            //_employeeRepository.DeleteEmployee(id);
            _employeeStorage.DeleteEmployee(id);
            return RedirectToAction("Employees"); 
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    //Another DB Context
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}