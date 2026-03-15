namespace Task2
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class Person
    {
        private int _age = 0;
        private static int _count = 0;
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
                    _count++;
                    throw new AccessException((_count).ToString());
                }
                else
                {
                    _age = value;
                }
            }
        }
    }
}
