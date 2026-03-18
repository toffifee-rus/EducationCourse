namespace Task5
{
    /// <summary>
    /// Задание 5
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Отображение работы синглтона
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Person p1 = Person.GetState();
            p1.id = 1;
            Person p2 = Person.GetState();
            p2.id = 2;
            Console.WriteLine(p1.id + " " + p2.id);
        }
    }
}