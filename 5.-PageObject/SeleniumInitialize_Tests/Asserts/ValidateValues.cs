using OpenQA.Selenium;
using SeleniumInitialize_Tests.Data;
using SeleniumInitialize_Tests.Pages;

namespace SeleniumInitialize_Tests.Asserts
{
    /// <summary>
    /// Валидация значений
    /// </summary>
    public class ValidateValues
    {
        private readonly IWebDriver _driver;

        public ValidateValues(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Проверка сгенерированных данных
        /// </summary>
        /// <param name="expectedUser"></param>
        public void DataAssert(User expectedUser)
        {
            ConfirmationPage confirmationPage = new ConfirmationPage(_driver);

            var actual = confirmationPage.GetData();

            Assert.AreEqual(actual.LastName, expectedUser.LastName, "Фамилия не совпадает");
            Assert.AreEqual(actual.FirstName, expectedUser.FirstName, "Имя не совпадает");
            Assert.AreEqual(actual.MiddleName, expectedUser.MiddleName, "Отчество не совпадает");

            string cleanActualDate = actual.BirthDate.Replace(".", "");
            Assert.AreEqual(cleanActualDate, expectedUser.BirthDate, "Дата рождения не совпадает");

            string cleanActualPhone = new string(actual.Phone.Where(char.IsDigit).ToArray());
            StringAssert.EndsWith(expectedUser.Phone, cleanActualPhone, "Телефон не совпадает");
        }
    }
}
