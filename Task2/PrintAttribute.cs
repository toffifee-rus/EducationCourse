namespace Task2
{
    /// <summary>
    ///  Класс для вывода аттрибута 
    /// </summary>
    public class PrintAttribute
    {
        /// <summary>
        /// Выводит аттрибут
        /// </summary>
        /// <example>Тестовый класс <br/>1.0</example>
        /// <exception cref="ArgumentNullException">Не найден кастомный атрибут</exception>
        public void PrintMyAttributeData()
        {
            Type type = typeof(Input);
            var attr = Attribute.GetCustomAttribute(type, typeof(Task2Attribute)) as Task2Attribute;
            ArgumentNullException.ThrowIfNull(attr);

            Console.WriteLine(attr.Name);
            Console.WriteLine(attr.Version);
        }
    }
}