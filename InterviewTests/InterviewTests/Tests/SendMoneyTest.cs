using InterviewTests.Asserts;
using InterviewTests.Pages;
using NUnit.Framework;

namespace InterviewTests.Tests
{
    /// <summary>
    /// Класс теста перевода денег между счетами
    /// </summary>
    [TestFixture]
    public class SendMoneyTest : BaseTest
    {
        /// <summary>
        /// Метод теста перевода денег между счетами
        /// </summary>
        /// <param name="senderCardNumber">Номер карты отправителя</param>
        /// <param name="transferSum">Сумма перевода</param>
        /// <param name="addresseeBill">Счет получателя</param>
        /// <param name="addresseeShortCardNumber">Последние 4 цифры номера карты получателя</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        [Test(Description = "Тест перевода денег между счетами")]
        [TestCase("2244000046031186", "999", "40800726845537541016", "7753", "Toffifee11", "A12345678")]
        public void SendMoney(string senderCardNumber, string transferSum, string addresseeBill, 
                              string addresseeShortCardNumber, string login, string password)
        {
            WelcomePage welcomePage = new WelcomePage(driver);
            welcomePage.Open(welcomePage.url);
            var element = wait.Until(d => d.FindElement(welcomePage.LoginButtonLocator));
            element.Click();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(login, password);

            MainPage mainPage = new MainPage(driver);
            string startBalance = mainPage.GetBalance(addresseeShortCardNumber);
            mainPage.MoneyTransfer(transferSum, senderCardNumber, addresseeBill);

            CompareMonyeAssert compareMonyeAssert = new CompareMonyeAssert(driver);
            compareMonyeAssert.CompareBalance(addresseeShortCardNumber, startBalance, transferSum);
        }
    }
}
