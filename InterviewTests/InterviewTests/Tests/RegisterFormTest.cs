using InterviewTests.Pages;
using NUnit.Framework;

namespace InterviewTests.Tests
{
    /// <summary>
    /// Класс теста регистрации нового пользователя
    /// </summary>
    [TestFixture]
    public class RegisterFormTest : BaseTest
    {
        /// <summary>
        /// Метод регистрации нового пользователя
        /// </summary>
        [Test(Description = "Тест регистрации")]
        public void RegisterForm()
        {
            WelcomePage welcomePage = new WelcomePage(driver);
            welcomePage.Open(welcomePage.url);
            var element = wait.Until(d => d.FindElement(welcomePage.RegistrationButtonLocator));
            element.Click();

            RegisterPage registerPage = new RegisterPage(driver);
            registerPage.FillForm();
        }
    }
}