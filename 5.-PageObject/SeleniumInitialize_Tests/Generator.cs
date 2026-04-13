namespace SeleniumInitialize_Tests
{
    /// <summary>
    /// Генератор случайных значений
    /// </summary>
    public static class Generator
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Генерация случайной строки длиной 8 символов
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateName(int length = 8)
        {
            const string chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Генерация случайной даты рождения от 19 до 80 лет
        /// </summary>
        /// <returns></returns>
        public static string GenerateBirthDate()
        {
            int year = _random.Next(DateTime.Now.Year - 80, DateTime.Now.Year - 19);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month));
            return $"{day:D2}{month:D2}{year}";
        }

        /// <summary>
        /// Генерация случайного номера телефона начинающегося с 9
        /// </summary>
        /// <returns></returns>
        public static string GeneratePhone() => "9" + _random.Next(100000000, 999999999);

        /// <summary>
        /// Выбор случайного гендера
        /// </summary>
        /// <returns></returns>
        public static string GenerateGender()
        {
            return _random.Next(1, 3) == 1 ? "Мужской" : "Женский";
        }
    }
}
