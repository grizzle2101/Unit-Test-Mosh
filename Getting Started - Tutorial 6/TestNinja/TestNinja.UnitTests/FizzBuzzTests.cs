using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //Section 4 - Tutorial 1 - FizzBuzz
    //Task 1 - Create Test Setup for FizzBuzz
    //Task 2 - Create Test Scenarios for GetOutput
    //Divisible by BOTH 3 & 5
    //Divisible by 3
    //Divisible by 5
    //Number that neither Divisible by 3 or 5
    //Task 3 - Implement Test Cases
    //Task 4 - Refactor if needed.

    //Task 1 - Create Test Setup for FizzBuzz
    [TestFixture]
    public class FizzBuzzTests
    {
        //Task 3 - Implement Test Cases
        //[Test]
        //public void GetOutput_IsDivisibleBy3And5_ShouldReturnFizzBuzz()
        //{
        //    //Arrange
        //    //Act
        //    var result = FizzBuzz.GetOutput(15);

        //    //Assert
        //    Assert.That(result, Is.EqualTo("FizzBuzz"));
        //}

        //[Test]
        //public void GetOutput_IsDivisibleBy3_ShouldReturnFizz()
        //{
        //    //Act
        //    var result = FizzBuzz.GetOutput(6);

        //    //Assert
        //    Assert.That(result, Is.EqualTo("Fizz"));

        //}

        //[Test]
        //public void GetOutput_IsDivisibleBy5_ShouldReturnBuzz()
        //{
        //    //Act
        //    var result = FizzBuzz.GetOutput(10);

        //    //Assert
        //    Assert.That(result, Is.EqualTo("Buzz"));

        //}

        //[Test]
        //public void GetOutput_IsNotDivisibleBy3Or5_ShouldReturnSame()
        //{
        //    //Act
        //    var result = FizzBuzz.GetOutput(2);

        //    //Assert
        //    Assert.That(result, Is.EqualTo("2"));
        //}

        //Task 4 - Refactor (Single Parametized Test)
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(2, "2")]
        public void GetOutput_IsDivisivle_Stuff(int value, string expected)
        {
            //Act
            var result = FizzBuzz.GetOutput(value);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
