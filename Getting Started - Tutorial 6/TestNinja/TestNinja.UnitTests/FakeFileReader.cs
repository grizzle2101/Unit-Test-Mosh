using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    //Task 3 - Create Test Double
    //In Unit Testing we have 2 types of fakes. Stubs and Mocks.
    //They both represent Mock objects, but some older Unit Test frameworks differenciate, but most modern frameworks dont.
    //We created the class in the Unit Test project, so this is seperate to our production code.
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
