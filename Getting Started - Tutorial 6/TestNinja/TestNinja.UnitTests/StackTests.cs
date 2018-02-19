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

        //Push Method Tests
        //Exception
        [Test]
        public void Push_PassInvalidObject_ShouldRaiseException()
        {
            //Assert
            //Issue here Null not triggering Exception, Move on & come back.
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
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
        [Test]
        public void Push_Pass2ValidObjects_Should2AddObjectToStack()
        {
            //Act
            _stack.Push("a");
            _stack.Push("b");

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        //Pop Method Tests
        //Remove from Empty Stack
        [Test]
        public void Pop_AttemptToRemoveItemNotExist_ShouldThrowInvalidOperationException()
        {

            //Assert
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);

        }

        //Happy Path Test
        [Test]
        public void Pop_RemoveValidItemFromList_ShouldReturnItem()
        {
            //Act
            _stack.Push("abc");
            var result = _stack.Pop();


            //Assert
            Assert.That(result, Is.EqualTo("abc"));

        }

        //Stack Sorting
        [Test]
        public void Pop_HaveMultipleValuesPopTop_ShouldReturnLast()
        {
            //Act
            _stack.Push("abc");
            _stack.Push("123");
            _stack.Push("xyz");

            var result = _stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("xyz"));
            Assert.That(_stack.Count, Is.EqualTo(2));

        }

        //Peek Method Tests
        //Error Handling
        [Test]
        public void Peek_PeekWithNoItemsInStack_RaiseInvalidOperationException()
        {

            //Assert
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }


        [Test]
        public void Peek_WhenCalled_ReturnsItemFromStack()
        {
            //Act
            _stack.Push("one");
            _stack.Push("two");
            _stack.Push("three");

            var result = _stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("three"));
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
