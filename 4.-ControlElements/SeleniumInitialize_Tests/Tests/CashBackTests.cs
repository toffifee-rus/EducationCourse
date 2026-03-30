using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;
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
            cashBackPage.CategoryClick();
            cashBackPage.CinemaClick();
            cashBackPage.PublicTransportClick();
            cashBackPage.SelectClick();
        }

        [Test(Description = "Метод взаимодействия с элементом выпадающий список")]
        public void ComboboxTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            string expectedValue = "Пушкин";
            cashBackPage.Open();
            cashBackPage.InputClick();
            cashBackPage.TypeInput();
            cashBackPage.PushkinClick();
            string actualValue = cashBackPage.GetInputValue();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test(Description = "Метод взаимодействия с кнопкой скачивания")]
        public void DownloadTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            string expectedUrl = "qpstorage/psb/images/yc_short_tarifs.pdf";
            cashBackPage.Open();
            cashBackPage.CashBackClick();
            cashBackPage.SwitchTab(1);
            _wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            Assert.AreEqual("https://www.psbank.ru/qpstorage/psb/images/yc_short_tarifs.pdf", cashBackPage.GetCurrentUrl());
        }
    }
}