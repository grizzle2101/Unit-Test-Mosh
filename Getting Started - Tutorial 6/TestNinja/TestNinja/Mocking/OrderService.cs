namespace TestNinja.Mocking
{
    //Tutorial 10 - Testing the Interaction between 2 objects
    public class OrderService
    {
        private readonly IStorage _storage;

        public OrderService(IStorage storage)
        {
            _storage = storage;
        }

        //Method under test, we want to make sure the correct order is passed to Storage Class.
        public int PlaceOrder(Order order)
        {
            //Sanity Check Test
            return 1;
            var orderId = _storage.Store(order);
            
            // Some other work

            return orderId; 
        }
    }

    public class Order
    {
    }

    public interface IStorage
    {
        int Store(object obj);
    }
}