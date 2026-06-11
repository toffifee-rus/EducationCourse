using InterviewTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace InterviewTests.Asserts
{
    /// <summary>
    /// Класс ассерта для проверки сумм балансов
    /// </summary>
    public class CompareMonyeAssert : BaseAssert
    {
        public CompareMonyeAssert(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Метод проверки сумм балансов
        /// </summary>
        /// <param name="addresseeShortCardNumber">Последние 4 цифры карты</param>
        /// <param name="startBalance">Начальный баланс счета получателя</param>
        /// <param name="transferSum">Сумма перевода</param>
        public void CompareBalance(string addresseeShortCardNumber, string startBalance, string transferSum)
        {
            TimeSpan timer = TimeSpan.FromSeconds(10);

            MainPage mainPage = new MainPage(_driver);

            string expectedBalance = Regex.Replace((decimal.Parse(Regex.Replace(startBalance, @"\s+", "")) 
                                      + decimal.Parse(transferSum)).ToString(), ",", ".");
            string currentBalance;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            do
            {
                var element = _wait.Until(d =>
                    d.FindElement(By.XPath($"//div[contains(text(), '{addresseeShortCardNumber}') ]" +
                                          $"/ancestor::div[./tui-money]//span[@automation-id = " +
                                          $"'tui-money__integer-part']")));

                currentBalance = Regex.Replace(element.Text, @"\s+", "");

                mainPage.RefreshPage();
            }

            while (currentBalance != expectedBalance && stopWatch.Elapsed < timer);

            Assert.That(currentBalance == expectedBalance, Is.True, 
                        $"Баланс не обновился до {expectedBalance}");
        }
    }
}