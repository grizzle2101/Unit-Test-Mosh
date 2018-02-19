using System;
using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    //Section 4 - Tutorial 4 - Stack Excercise:
    //So we have a Class here that is a Generic Stack.
    public class Stack<T>
    {
        private readonly List<T> _list = new List<T>();

        //Return Count of the Stack
        public int Count => _list.Count;

        //Add Object to Stack
        public void Push(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            
            _list.Add(obj);
        }

        //Remove Object from Stack
        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            var result = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);

            return result; 
        }

        //Show Item from Stack, but not Remove.
        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            return _list[_list.Count - 1];
        }
    }
}