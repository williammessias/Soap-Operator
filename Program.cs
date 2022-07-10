namespace DemoOperator
{
    #region Usings
    using System;
    using System.Threading.Tasks;
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Operator!");

            RunCalculation();
        }

        static void RunCalculation()
        {
            OperatorRepository OperatorRepository = new OperatorRepository("http://www.dneonline.com/calculator.asmx", 1000);

            Console.WriteLine("What calculation would you like to perform:");
            Console.WriteLine("  1. Addition");
            Console.WriteLine("  2. Subtraction");
            Console.WriteLine("  3. Multiplication");
            Console.WriteLine("  4. Division");

            Console.WriteLine("Enter the number of your decision:");
            int decision = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your first number:");
            int intA = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your second number:");
            int intB = Convert.ToInt32(Console.ReadLine());

            Task<int> calculation;

            switch (decision)
            {
                case 1:
                    calculation = OperatorRepository.AddAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} + {intB} = {calculation.Result}");
                    break;

                case 2:
                    calculation = OperatorRepository.SubtractAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} - {intB} = {calculation.Result}");
                    break;

                case 3:
                    calculation = OperatorRepository.MultiplyAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} × {intB} = {calculation.Result}");
                    break;

                case 4:
                    if (intB == 0)
                    {
                        Console.WriteLine("Error: You cannot divide a number by 0!");
                    }
                    else
                    {
                        calculation = OperatorRepository.DivideAsync(intA, intB);
                        calculation.Wait();
                        Console.WriteLine($"{intA} ÷ {intB} = {calculation.Result}");
                    }

                    break;

                default:
                    Console.WriteLine("Error: You must enter a number between 1 and 4!");
                    break;
            }
        }
    }
}