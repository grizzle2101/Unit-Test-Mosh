namespace TestNinja.Mocking
{
    ////Task 1 - Extract External Resource Calls
    //public class EmployeeRepository : IEmployeeRepository
    //{
    //    private EmployeeContext _db;

    //    public void DeleteEmployee(int id)
    //    {
    //        var employee = _db.Employees.Find(id);
    //        _db.Employees.Remove(employee);
    //        _db.SaveChanges();
    //    }
    //}

    ////Task 2 - Program to Interface
    //public interface IEmployeeRepository
    //{
    //    void DeleteEmployee(int id);
    //}

    //Mosh Way
    //Naming EmployeeStorage
    //Some people use the word Services, but Mosh reserves the word Service for High Level Orchestration.
    //Meaning at a high level delegating task to other objects like  triggering  Notifications, Logging etc.
    //It should not be called Repository, because Repositories do not Save Data.
    
    //Nice that Extracting this will allow us to Abstract out Entity Framework, if we choose to change the
    //Implementation the Controller won't care, as long as it has a mechanism to delete.
    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }

    public interface IEmployeeStorage
    {
        void DeleteEmployee(int id);
    }
}