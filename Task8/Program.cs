namespace Task8
{
    /// <summary>
    /// Задание 7
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Пример вывода
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Registration<Employee> registration = new Registration<Employee>();

            Employee employee = new()
            {
                Name = "Никита"
            };

            Developer developer = new()
            {
                Name = "Костя",
                MainLanguage = "python"
            };

            Manager manager = new()
            {
                Name = "Кирилл",
                Wards = 5
            };

            registration.AddPerson(employee);
            registration.AddPerson(manager);
            registration.AddPerson(developer);
            registration.PrintAll();
        }
    }
}