using InterviewTests.Models;
using OpenQA.Selenium;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс страницы регистрации
    /// </summary>
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        public By PhoneLocator = By.XPath(@"//input[@type = ""tel""]");
        public By LoginLocator = By.XPath(@"//tui-input[.//*[text() = "" Логин ""]]//input[@type = ""text""]");
        public By EmailLocator = By.XPath(@"//tui-input[.//*[text() = "" e-mail ""]]//input[@type = ""text""]");
        public By LastNameLocator = By.XPath(@"//tui-input[.//*[text() = "" Фамилия ""]]//input[@type = ""text""]");
        public By FirstNameLocator = By.XPath(@"//tui-input[.//*[text() = "" Имя ""]]//input[@type = ""text""]");
        public By MiddleNameLocator = By.XPath(@"//tui-input[.//*[text() = "" Отчество ""]]//input[@type = ""text""]");
        public By BirthdayLocator = By.XPath(@"//label[contains(text(), ""Дата рождения"")]/ancestor::tui-input-date//input");
        public By MaleGenderLocator = By.XPath(@"//tui-radio-labeled[1]/label/tui-radio/div/input");
        public By FamaleGenderLocator = By.XPath(@"//tui-radio-labeled[2]/label/tui-radio/div/input");
        public By AddressLocator = By.XPath(@"//tui-input[.//*[text() = "" Адресс ""]]//input[@type = ""text""]");
        public By CreatePasswordLocator = By.XPath(@"//label[contains(text(), ""Придумайте пароль"")]/ancestor::tui-input-password//input[@type = ""password""]");
        public By RewritePasswordLocator = By.XPath(@"//label[contains(text(), ""Повторите пароль"")]/ancestor::tui-input-password//input[@type = ""password""]");
        public By SubmitButtonLocator = By.XPath(@"//button[@type = ""submit""]");

        /// <summary>
        /// Метод заполнения формы регистрации данными пользователя
        /// </summary>
        public void FillForm()
        {
            UserModel user = new UserModel();

            _driver.InputElement(PhoneLocator, user.Phone);
            _driver.InputElement(LoginLocator, user.Login);
            _driver.InputElement(EmailLocator, user.Email);
            _driver.InputElement(LastNameLocator, user.LastName);
            _driver.InputElement(FirstNameLocator, user.FirstName);
            _driver.InputElement(MiddleNameLocator, user.MiddleName);
            _driver.InputElement(BirthdayLocator, user.Birthday);
            _driver.InputElement(AddressLocator, user.Address);

            switch (user.Gender)
            {
                case Gender.Мужской: _driver.ClickElement(MaleGenderLocator);
                    break;
                case Gender.Женский: _driver.ClickElement(FamaleGenderLocator);
                    break;
            }

            _driver.InputElement(CreatePasswordLocator, user.Password);
            _driver.InputElement(RewritePasswordLocator, user.Password);
        }
    }
}