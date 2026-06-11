using InterviewTests.Asserts;
using InterviewTests.Models;
using InterviewTests.Pages;
using NUnit.Framework;

namespace InterviewTests.Tests
{
    /// <summary>
    /// Класс теста выпуска новой карты
    /// </summary>
    [TestFixture]
    public class OrderCardTest : BaseTest
    {
        /// <summary>
        /// Метод теста выпуска новой карты
        /// </summary>
        /// <param name="cardType">Тип выпускаемой карты</param>
        /// <param name="releaseProgram">Тип программы выпуска</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        [Test(Description = "Тест выпуска новой карты")]
        [TestCase(CardType.Дебетовая, ReleaseProgram.МИР, "Новая", "Toffifee11", "A12345678")]
        public void OrderCard(CardType cardType, ReleaseProgram releaseProgram, string login, 
                              string password)
        {
            WelcomePage welcomePage = new WelcomePage(driver);
            welcomePage.Open(welcomePage.url);
            var element = wait.Until(d => d.FindElement(welcomePage.LoginButtonLocator));
            element.Click();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(login, password);

            MainPage mainPage = new MainPage(driver);
            element = wait.Until(d => d.FindElement(mainPage.OrderCardLocator));
            element.Click();

            ReleaseCardPage releaseCardPage = new ReleaseCardPage(driver);
            releaseCardPage.ReleaseCard(cardType, releaseProgram);

            NewCardAssert newCardAssert = new NewCardAssert(driver);
            newCardAssert.WaitForCardToFinish();
        }
    }
}