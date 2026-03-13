namespace task2
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
            Person person = new Person();
            person.Age = Convert.ToInt32(args[0]);
        }
    }
}