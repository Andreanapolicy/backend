namespace Calculator
{
    class Program
    {
        public enum Operations
        {
            Plus = '+',
            Minus = '-',
            Division = '/',
            Multiplication = '*'
        }

        public static int Main(string[] args)
        {
            WriteGreetings();

            return 0;
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
