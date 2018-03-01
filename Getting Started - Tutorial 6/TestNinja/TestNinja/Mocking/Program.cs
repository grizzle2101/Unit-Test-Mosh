using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class Program
    {
        //Task 2 - Create Production Implementation
        public static void Main()
        {
            var service = new VideoService();
            service.ReadVideoTitle(new FileReader());
        }
    }
}
