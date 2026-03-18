namespace Task5
{
    /// <summary>
    /// Сигнлтон обьявление пользователя
    /// </summary>
    public sealed class Person
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        private Person() { }

        /// <summary>
        /// Статическая переменная для состояния
        /// </summary>
        private static Person _state;

        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int id;

        /// <summary>
        /// Метод для получения состояния
        /// </summary>
        /// <returns></returns>
        public static Person GetState()
        {
            return _state == null ? (_state = new Person()) : _state;
        }
    }
}
