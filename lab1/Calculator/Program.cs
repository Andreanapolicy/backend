using System.Globalization;

namespace Calculator
{
    class Program
    {
        private enum Operations
        {
            Plus = '+',
            Minus = '-',
            Division = '/',
            Multiplication = '*'
        }

        private struct Args
        {
            public float firstOperand;
            public float secondOperand;
            public Operations operation;
        }

        public static int Main()
        {
            WriteGreetings();
            try
            {
                Args args = ParseArgs();

                float result = GetCalculatedResult(args);
                WriteResult(ref args, result);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                return 1;
            }
            return 0;
        }

        private static Args ParseArgs()
        {
            float firstOperand = GetNumber("first operand: ");
            float secondOperand = GetNumber("second operand: ");
            Operations operation = GetOperation("operation: ");

            return new Args{firstOperand = firstOperand, secondOperand = secondOperand, operation = operation};
        }

        private static float GetCalculatedResult(Args args)
        {
            if (args.operation == Operations.Division && args.secondOperand == 0)
            {
                throw new DivideByZeroException("second operand is zero");
            }

            float result = args.operation switch
            {
                Operations.Plus => args.firstOperand + args.secondOperand,
                Operations.Minus => args.firstOperand - args.secondOperand,
                Operations.Division => args.firstOperand / args.secondOperand,
                Operations.Multiplication => args.firstOperand * args.secondOperand,
                _ => throw new ApplicationException("wrong operation type")
            };

            if (float.IsPositiveInfinity(result) || float.IsNegativeInfinity(result))
            {
                throw new ArgumentOutOfRangeException("result is out of range");
            }

            return result;
        }

        private static float GetNumber(string? message = null)
        {
            if (message != null)
            {
                Console.Write(message);
            }

            if (!float.TryParse(Console.ReadLine(), out float number))
            {
                throw new InvalidCastException("can`t read number");
            }

            if (float.IsPositiveInfinity(number) || float.IsNegativeInfinity(number))
            {
                throw new ArgumentOutOfRangeException("you can pass only float number");
            }

            return number;
        }

        private static Operations GetOperation(string? message = null)
        {
            if (message != null)
            {
                Console.Write(message);
            }

            string? operation;

            if ((operation = Console.ReadLine()) == null)
            {
                throw new InvalidCastException("can`t read operation");
            }

            return operation switch
            {
                "+" => Operations.Plus,
                "-" => Operations.Minus,
                "/" => Operations.Division,
                "*" => Operations.Multiplication,
                _ => throw new ArgumentException("wrong operation")
            };
        }

        private static void WriteResult(ref Args args, float result)
        {
            NumberFormatInfo precision = new NumberFormatInfo();
            precision.NumberDecimalDigits = 2;
            Console.WriteLine(args.firstOperand.ToString("N", precision) + " " +
                              (char) args.operation + " " +
                              args.secondOperand.ToString("N", precision) + " = " +
                              result.ToString("N", precision));
        }

        private static void WriteGreetings()
        {
            Console.WriteLine("This is console app `Calculator`");
            Console.WriteLine("How to work with it:");
            Console.WriteLine("1) Enter first operand(float or int). E.x. 12");
            Console.WriteLine("2) Enter second operand(float or int). E.x. 34.02");
            Console.WriteLine("3) Enter operation(" + GetAllOperation() + ". E.x. /");
            Console.WriteLine("As the result you will get: 12 / 34.02 = 0.35");
            Console.WriteLine("=============================================");
        }

        private static string GetAllOperation()
        {
            return Operations.Plus + ", " +
                   Operations.Minus + ", " +
                   Operations.Division + ", " +
                   Operations.Multiplication + ", ";
        }
    }
}
