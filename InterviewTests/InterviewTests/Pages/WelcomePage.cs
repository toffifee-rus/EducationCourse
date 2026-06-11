using OpenQA.Selenium;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс страницы приветствия
    /// </summary>
    public class WelcomePage : BasePage
    {
        public WelcomePage(IWebDriver driver) : base(driver) { }

        public string url = "https://itester.online//getAccess?token=2ad3f9a0ee6b486db902ade89d6850ff";

        public By RegistrationButtonLocator = By.XPath("//span[text() = \" Зарегистрироваться \"]/../..");
        public By LoginButtonLocator = By.XPath("//tui-block-status//span[text() = ' Войти ']/ancestor::button");
    }
}