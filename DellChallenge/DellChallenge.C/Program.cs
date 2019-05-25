using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            ComputeDisplaySumResults();
            Console.ReadKey();
        }

        private static void ComputeDisplaySumResults()
        {
            Sum s = new Sum();
            int firstOperationSum = s.SampleSum(1, 3);
            int secondOperationSum = s.ExtendedSum(1, 3, 5);
            Console.WriteLine(firstOperationSum);
            Console.WriteLine(secondOperationSum);
        }
    }

    public class Sum
    {
        public int SampleSum(int a, int b)
        {
            return a + b;
        }

        public int ExtendedSum(int a, int b, int c)
        {
            return SampleSum(a, b) + c;
        }
    }
}
