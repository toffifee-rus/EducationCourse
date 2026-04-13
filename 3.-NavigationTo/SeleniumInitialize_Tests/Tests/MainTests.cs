using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;
using SeleniumInitialize_Tests.Pages;

namespace SeleniumInitialize_Tests.Tests
{
    [TestFixture]
    public class MainTests : BaseTest
    {
        [Test(Description = "Задание 1 Определить уникальный элемент")]
        public void UniqueElementTest()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.Open();
            _wait.Until(d => mainPage.IsUniqueDisplayed());
            Assert.IsTrue(mainPage.IsUniqueDisplayed());
            TestContext.WriteLine($"Страница: Главная, тип локатора: XPath, значение локатора: //div[@class= 'main']");
        }

        [Test(Description = "Задание 2 Реализовать метод для ожидание загрузки страниц из предыдущей задачи")]
        public void PageLoadTest()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.Open();
            _wait.Until(d => mainPage.IsBannerDisplayed());
            Assert.IsTrue(mainPage.IsBannerDisplayed());
            // джава скрипт полная прогрузка страниц
        }

        [Test(Description = "Задача 3 Проверить переход по ссылке внутри элемента")]
        public void TransitionTest()
        {
            MainPage mainPage = new MainPage(_driver);
            string expectedUrl = "store/products/investmentsbrokerage";
            mainPage.Open();
            mainPage.InvestmentsClick();
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", mainPage.GetBrokerageHref());
            mainPage.BrokerageClick();
            _wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", mainPage.GetCurrentUrl());

        }
    }
}