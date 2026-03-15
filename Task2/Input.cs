using System.Text.Json;

namespace Task2
{
    /// <summary>
    /// Ввод начальных данных
    /// </summary>
    [Task2("Класс ввода массива", "2.0")]
    public static class Input
    {
        /// <summary>
        /// Свойство для массива пользователей
        /// </summary>
        public static List<Person> Person { get; } = new List<Person>();

        /// <summary>
        /// Конструктор класса
        /// </summary>
        static Input()
        { 
            try
            {
                /// <summary>
                /// Строка для прочитанного из файла текста
                /// </summary>
                string JsonString = File.ReadAllText("persons.json");
                Console.WriteLine(JsonString);

                /// <summary>
                /// Сырые данные из Json файла
                /// </summary>
                var raw = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(JsonString);

                /// <summary>
                /// Цикл для перехода по всем элементам массива
                /// </summary>
                foreach (var i in raw)
                {
                    try
                    {
                        Person p = new Person
                        {
                            Name = i["Name"].ToString(),
                            Age = int.Parse(i["Age"].ToString())
                        };
                        Person.Add(p);
                        Console.WriteLine($"Пользователь {i["Name"]} Добавлен");
                    }
                    catch (AccessException ex)
                    {
                        Console.WriteLine($"Пропущен: {i["Name"]} (Ошибка: {ex.TransactionId})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Загрузка прервана из-за валидации: {ex.Message}");
                Person = new List<Person>();
                
            }
        }
    }
}
