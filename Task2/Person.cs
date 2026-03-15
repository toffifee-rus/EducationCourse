namespace Task2
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class Person
    {
        private int _age = 0;

        /// <summary>
        /// Возраст
        /// </summary>
        public string Name { get; set; }

        public int Age
        {
            get
            {
                if (_age == 0)
                {
                    throw new ArgumentNullException("Не задан возраст");
                }
                return _age;
            }
            set
            {
                if (value < 18)
                {
                    throw new AccessException("001");
                }
                else
                {
                    _age = value;
                }
            }
        }
    }
}
