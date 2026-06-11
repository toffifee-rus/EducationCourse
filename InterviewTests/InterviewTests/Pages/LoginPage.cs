using OpenQA.Selenium;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс страницы логина
    /// </summary>
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public By LoginLocator = By.XPath(@"//tui-input[.//*[text() = "" Логин ""]]//input[@type = ""text""]");
        public By PasswordLocator = By.XPath(@"//input[@type = ""password""]");
        public By SubmitButtonLocator = By.XPath("//button[@type = 'submit']");

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        public void Login(string Login, string Password)
        {
            _driver.InputElement(LoginLocator, Login);
            _driver.InputElement(PasswordLocator, Password);
            _driver.ClickElement(SubmitButtonLocator);
        }
    }
}