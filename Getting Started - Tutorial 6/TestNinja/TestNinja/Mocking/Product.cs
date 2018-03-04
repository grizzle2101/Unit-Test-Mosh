namespace TestNinja.Mocking
{
    //Tutorial 12 - Mock Abuse
    public class Product
    {
        public float ListPrice { get; set; }

        //Method Under Test

        public float GetPrice(ICustomer customer)
        {
            if (customer.IsGold)
                return ListPrice * 0.7f;

            return ListPrice;
        }
    }

    //Task 4 - Abuse Some Mocks - Extract Customer to Interface
    //People who abuse Mocks create interfaces from every class.
    public interface ICustomer
    {
        bool IsGold { get; set; }
    }

    public class Customer : ICustomer
    {
        public bool IsGold { get; set; }
    }
}