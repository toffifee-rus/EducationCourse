namespace Task3
{
    /// <summary>
    /// Класс
    /// </summary>
    public static class StaticTest
    {
        public static int Counter = 1;

        static StaticTest()
        {

        }

        public static int TestPlus(int x)
        {
            return ++x;
        }
    }
}
