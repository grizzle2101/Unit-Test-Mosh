using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    public class Math
    {
        //Tutorial 8 - Single Execution Path = Single Test.
        //Task 2 - Create Test for Add Function
        public int Add(int a, int b)
        { 
            return a + b;
        }
        
        //Tutorial 7 - Task 3 - Create Tests for Max Function
        //2 Execution Paths = 2 Tests.
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i; 
        }
    }
}