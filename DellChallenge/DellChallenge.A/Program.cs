using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)//to be completed!!!!!s
        {
            // State and explain console output order.

            /* For this program the console output order is:
            A.A()
            B.B()
            A.Age

            -First it will execute A.A() before B.B() because the object of type B will call the constructor of A class before the 
            constructor of B class. After the creation of an object the constructor in base class will be executed before the derivated 
            class constructor as the first will display in the console is "A.A()" and the second wil be "B.B().

            -The display of A.Age at the end after the A.A() and B.B() represent the result of the assignment of a value to the
            property Age defined in class A. In property A the setter assign the value 0 to the private field _age and will display
            the value A.Age.
            */

            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
