namespace Task8
{
    /// <summary>
    /// Обычный сотрудник
    /// </summary>
    public class Employee
    {
        public string Name;

        /// <summary>
        /// Вывод данных о пользователе с возможнстью переопределения
        /// </summary>
        public virtual void GetInfo()
        {
            Console.WriteLine($"Сотрудник {Name}");
        }
    }

    /// <summary>
    /// Разработчик с доп полем MainLanguage
    /// </summary>
    public class Developer : Employee
    {
        public string MainLanguage;

        /// <summary>
        /// Переопределённый вывод данных о разработчике
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine($"Разработчик {Name}, язык - {MainLanguage}");
        }
    }

    /// <summary>
    /// Менеджер с доп полем Wards (Подопечные)
    /// </summary>
    public class Manager : Employee
    {
        public int Wards;

        /// <summary>
        /// Переодпределённый вывод данных о менеджере
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine($"Менеджер {Name}, размер команды - {Wards}");
        }
    }

    /// <summary>
    /// Класс обобщений, где T : Employee
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Registration<T> where T : Employee
    {
        public List<T> persons = new List<T>();

        /// <summary>
        /// Добавление сотрудника в общий список
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(T person)
        {
            persons.Add(person);
        }

        /// <summary>
        /// Вывод всех сотрудников
        /// </summary>
        public void PrintAll()
        {

            foreach (T person in persons)
            {
                person.GetInfo();
            }
        }
    }
}
