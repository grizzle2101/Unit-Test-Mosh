using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class Program
    {
        public static void Main()
        {
            //Task 1 - Changing the Constructor Signature - Breaks Existing Code.
            //var service = new VideoService(new FileReader());

            //Task 2 - Default Constructor - Avoids Breaking Production Code.
            //Task 3 - Constructor w Optional Param - Avoids Breaking Production Code & Duplication
            var service = new VideoService();
            service.ReadVideoTitle();
        }
    }
}
