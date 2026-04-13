using OpenQA.Selenium;

namespace SeleniumInitialize_Tests.Pages
{
    /// <summary>
    /// Страница проверки введённых данных
    /// </summary>
    public class ConfirmationPage : BasePage
    {
        public ConfirmationPage(IWebDriver driver) : base(driver) { }

        private readonly By _lastName = By.XPath("//span[contains(text(), 'Фамилия')]/following-sibling::b");
        private readonly By _firstName = By.XPath("//span[contains(text(), 'Имя')]/following-sibling::b");
        private readonly By _middleName = By.XPath("//span[contains(text(), 'Отчество')]/following-sibling::b");
        private readonly By _birthday = By.XPath("//span[contains(text(), 'Дата')]/following-sibling::b");
        private readonly By _phone = By.XPath("//span[contains(text(), 'телефон')]/following-sibling::b");

        /// <summary>
        /// Извлечение текущих данных
        /// </summary>
        /// <returns></returns>
        public (string LastName, string FirstName,string MiddleName, string BirthDate, string Phone) GetData()
        {

            return (
                LastName: _driver.FindElement(_lastName).Text.Trim(),
                FirstName: _driver.FindElement(_firstName).Text.Trim(),
                MiddleName: _driver.FindElement(_middleName).Text.Trim(),
                BirthDate: _driver.FindElement(_birthday).Text.Trim(),
                Phone: _driver.FindElement(_phone).Text.Trim()
            );
        }
    }
}
