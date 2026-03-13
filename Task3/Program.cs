using Task3;

namespace task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(StaticTest.Counter);
            Console.WriteLine(TestPlus(StaticTest.Counter));
        }
    }
}
