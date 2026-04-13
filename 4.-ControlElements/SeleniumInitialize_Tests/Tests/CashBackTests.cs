using SeleniumInitialize_Tests.Pages;

namespace SeleniumInitialize_Tests.Tests
{
    [TestFixture]
    public class CashBackTests : BaseTest
    {
        [Test(Description = "Метод взаимодействия с CheckBox")]
        public void SelectCheckboxTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            cashBackPage.Open();

            cashBackPage.CategoryButton.Click();

            cashBackPage.Cinema.Uncheck();
            cashBackPage.Transport.Check();

            cashBackPage.SelectButton.Click();
        }

        [Test(Description = "Метод взаимодействия с элементом выпадающий список")]
        public void ComboboxTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            string expectedValue = "Пушкин";
            cashBackPage.Open();

            cashBackPage.LastName.SelectElementAndClick(expectedValue, "Пу");
            string actualValue = cashBackPage.GetInputValue();
            Assert.AreEqual(expectedValue, actualValue, "Полученная строка не соответствует ожидаемой");
        }

        [Test(Description = "Метод взаимодействия с кнопкой скачивания")]
        public void DownloadTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            cashBackPage.Open();
            cashBackPage.OpenInNewTab();
            cashBackPage.Assert.UrlAssert(cashBackPage.GetCurrentUrl());
        }
    }
}