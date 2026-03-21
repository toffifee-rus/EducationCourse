//Дана коллекция чисел. Необходимо реализовать метод, который находит в ней пару чисел, составляющие заданную сумму.

//Пример:
//HasPairWithSum(new List<int> { 10, 4, 3, 7 }, 8); //false
//HasPairWithSum(new List<int> { 1, 4, 4, 9 }, 8); //true
namespace Task7
{
    /// <summary>
    /// Задание 7
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Примеры вывода функции
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(HasPairWithSum(new List<int> { 10, 4, 3, 7 }, 8));
            Console.WriteLine(HasPairWithSum(new List<int> { 1, 4, 4, 9 }, 8));
        }

        /// <summary>
        /// Функция с двумя циклами для прохождения по всем числам и поиска пары, которая образует результат
        /// </summary>
        /// <param name="nums">Массив целых чисел</param>
        /// <param name="result">Целое число</param>
        /// <returns>Булево значение</returns>
        public static bool HasPairWithSum(List<int> nums, int result)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = i+1; j != nums.Count(); j++)
                {
                    if (nums[i] + nums[j] == result)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}