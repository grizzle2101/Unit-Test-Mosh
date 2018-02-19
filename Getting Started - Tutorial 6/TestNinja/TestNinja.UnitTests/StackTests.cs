using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    //Section 4 - Tutorial 4 - Stack Excercise:
    //Task 1 - Create Test Setup
    //Task 2 - Analyze Methods for Test Scenarios
        //-Void Method Push - Valid Object - Invalid Object
        //-Return Method Pop - PopWhenNoItemInList & PopWhenItemInList
    //Task 3 - Implment Test Scernarios
    //Task 4 - Refactor if Neccessary

    //Task 1 - Create Test Setup
    [TestFixture]
    public class StackTests
    {
        public Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _stack = new Stack<string>();
        }

        //Push Invalid Object
        //Testing Exception
        [Test]
        public void Push_PassInvalidObject_ShouldRaiseException()
        {
            //Act
            //Assert
            var stack = new Stack<string>();

            stack.Push(null);

            //Issue here Null not triggering Exception, Move on & come back.
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        //Push Valid Object
        //Testing Void Method
        [Test]
        public void Push_PassValidObject_ShouldAddObjectToStack()
        {
            //Act
            _stack.Push("a");

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        //Additional Test for Count, as Count could return 1 and just pass, we need to test more than 1.

        //Pop Method Tests

        //Peek Method Tests
    }
}
