namespace Task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(StaticTest.Counter);
            Console.WriteLine(StaticTest.TestPlus(StaticTest.Counter));
        }
    }
}
