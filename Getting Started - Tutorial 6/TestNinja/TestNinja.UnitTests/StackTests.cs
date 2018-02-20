using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

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
        public TestNinja.Fundamentals.Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _stack = new Fundamentals.Stack<string>();
        }

        //Push Exception Handling
        [Test]
        public void Push_NullObject_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        //Push Valid Object
        [Test]
        public void Push_PassValidObject_ShouldAddObjectToStack()
        {
            //Act
            _stack.Push("a");

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        //Count Method
        [Test]
        public void Count_PassNothing_CountShouldRemain0()
        {
            //Act
            //Assert
            Assert.That(_stack.Count, Is.EqualTo(0));
        }


        //Pop Exception Handling
        [Test]
        public void Pop_EmptyStack_ShouldThrowInvalidOperationException()
        {
            //Assert
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        //Pop - Return Last Item
        [Test]
        public void Pop_StackWithAFewObjects_ShouldReturnLastItem()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            //Act
            var result = _stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        //Pop - Stack Count
        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTop()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            //Act
            var result = _stack.Pop();

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        //Peek - Empty Stack
        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            //Assert
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        //Peek - Shows Valid Object
        [Test]
        public void Peek_StackWithAFewObjects_ReturnsItemFromStack()
        {
            //Act
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        //Peek - Does not remove Object
        [Test]
        public void Peek_StackWithAFewObjects_DoesNotRemoveItemFromStack()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            //Act
            _stack.Peek();

            //Assert
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
