using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumInitialize_Builder;
using SeleniumInitialize_Tests.Pages;

namespace SeleniumInitialize_Tests.Tests
{
    [TestFixture]
    public class CreditTests : BaseTest
    {
        [Test(Description = "Задание 4. Проверка отображения номера лицензии и даты")]
        public void LicenseAndDateTest()
        {
            CreditPage creditPage = new CreditPage(_driver);
            InvestmentsPage investmentsPage = new InvestmentsPage(_driver);
            string textMask = @".*Генеральная лицензия на осуществление банковских операций № \d\d\d\d от \d\d? .* \d\d\d\d";
            creditPage.Open();
            Assert.IsTrue(creditPage.IsUniqueDisplayed(), "страница кредита не загрузилась");
            creditPage.OpenInvestmentsInNewTab();
            Assert.IsTrue(investmentsPage.IsUniqueDisplayed(), "страница инвестиций не загрузилась");
            string investLicense = creditPage.GetLicenseInfo();
            Assert.That(investLicense, Does.Match(textMask), "Лицензия на странице инвестиций не соответствует маске");
            creditPage.CloseAndSwitchTab(0);
            string creditLicense = creditPage.GetLicenseInfo();
            Assert.That(creditLicense, Does.Match(textMask), "Лицензия на странице кредита не соответствует маске");
        }

        [Test(Description = "Задание 1 Определить уникальный элемент")]
        public void UniqueElementTest()
        {
            CreditPage creditPage = new CreditPage(_driver);
            creditPage.Open();
            _wait.Until(d => creditPage.IsUniqueDisplayed());
            Assert.IsTrue(creditPage.IsUniqueDisplayed());
            TestContext.WriteLine($"Страница: Кредит, тип локатора: XPath, значение локатора: //div[@class='col']");
        }
    }
}
