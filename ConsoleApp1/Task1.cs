namespace Task1
{
    /// <summary>
    ///  Класс для вывода аттрибута 
    /// </summary>
    [Task("Тестовый класс", "1.0")]
    public class PrintTask
    {
        /// <summary>
        /// Выводит аттрибут
        /// </summary>
        /// <example>Тестовый класс <br/>1.0</example>
        /// <exception cref="ArgumentNullException">Не найден кастомный атрибут</exception>
        public void PrintMyAttributeData()
        {
            var attr = Attribute.GetCustomAttribute(GetType(), typeof(TaskAttribute)) as TaskAttribute;
            ArgumentNullException.ThrowIfNull(attr);

            Console.WriteLine(attr.Name);
            Console.WriteLine(attr.Version);
        }
    }
}