using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Tests.Data;
using SeleniumInitialize_Tests.Elements;

namespace SeleniumInitialize_Tests.Pages
{
    /// <summary>
    /// Страница кредита
    /// </summary>
    public class CreditPage : BasePage
    {
        public CreditPage(IWebDriver driver) : base(driver) { }

        private readonly By _comboboxCitizenship = By.XPath("//label[text() = 'Гражданство']/following-sibling::textarea");
        private readonly By _citizenshipListItemRUS = By.XPath("//sng-select-option[text()=' РФ ']");
        private readonly By _comboboxEmployment = By.XPath("//label[text() = 'Официальное трудоустройство']/following-sibling::textarea");
        private readonly By _employmentListItemHave = By.XPath("//sng-select-option[text() = ' Есть ']");

        public string Url = "https://ib.psbank.ru/store/products/credit-limit";

        public CheckBox MaleCheckBox => new CheckBox(_driver, By.XPath("//input[@title='Мужской']"));
        public CheckBox FemaleCheckBox => new CheckBox(_driver, By.XPath("//input[@title='Женский']"));

        public ComboBox CitizenshipCombo => new ComboBox(_driver, By.Name("//label[text() = 'Гражданство']"));

        public Button AllowButton => new Button(_driver, By.XPath("//span[@class='psb-checkbox__box']"));
        public Button ContinueButton => new Button(_driver, By.XPath("//button[@type='submit']"));
        public Button CookiesButton => new Button(_driver, By.XPath("//span[text() = 'Хорошо']"));

        public Input LastNameInput => new Input(_driver, By.XPath("//label[text() = 'Фамилия']/following-sibling::input"));
        public Input FirstNameInput => new Input(_driver, By.XPath("//label[text() = 'Имя']/following-sibling::input"));
        public Input MiddleNameInput => new Input(_driver, By.XPath("//label[text() = 'Отчество']/following-sibling::input"));
        public Input BirthDayInput => new Input(_driver, By.XPath("//label[text() = 'Дата рождения']/following-sibling::input"));
        public Input PhoneInput => new Input(_driver, By.XPath("//input[@name = 'Phone']"));

        /// <summary>
        /// Переход на страницу
        /// </summary>
        public void Open() => _driver.Navigate().GoToUrl(Url);

        /// <summary>
        /// Заполнение модели User данными
        /// </summary>
        /// <param name="user"></param>
        public void FillPage(User user)
        {
            LastNameInput.Fill(user.LastName);
            FirstNameInput.Fill(user.FirstName);
            MiddleNameInput.Fill(user.MiddleName);

            BirthDayInput.Fill(user.BirthDate);
            PhoneInput.Fill(user.Phone);

            CookiesButton.Click();
            AllowButton.Click();

            SelectGender(user.Gender);
            SelectItemRF();
            SelectItemHave();

            ContinueButton.Click();
        }

        /// <summary>
        /// Выбор гендера
        /// </summary>
        /// <param name="gender"></param>
        public void SelectGender(string gender)
        {

            CheckBox genderLocator = new(_driver, By.XPath($"//input[@title='{gender}']"));

            genderLocator.Check();
        }

        /// <summary>
        /// Выбор предмета "РФ" в комбобоксе
        /// </summary>
        /// <returns></returns>
        public CreditPage SelectItemRF()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_comboboxCitizenship)).Click();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_citizenshipListItemRUS)).Click();
            return this;
        }

        /// <summary>
        /// Выбор предмета "Есть" в комбобоксе
        /// </summary>
        /// <returns></returns>
        public CreditPage SelectItemHave()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_comboboxEmployment)).Click();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_employmentListItemHave)).Click();
            return this;
        }
    }
}
