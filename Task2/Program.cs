namespace Task2
{
    /// <summary>
    /// Задание 2
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Запрос возраста от пользователя
        /// </summary>
        /// <param name="args">Целое число</param>
        static void Main(string[] args)
        {
            PrintAttribute task2 = new PrintAttribute();
            task2.PrintMyAttributeData();
            Console.WriteLine(Input.Person);
        }
    }
}