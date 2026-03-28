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
    public class InvestmentsTests : BaseTest
    {
        [Test(Description = "Задание 1 Определить уникальный элемент")]
        public void UniqueElementTest()
        {
            InvestmentsPage investmentsPage = new InvestmentsPage(_driver);
            investmentsPage.Open();
            _wait.Until(d => investmentsPage.IsUniqueDisplayed());
            Assert.IsTrue(investmentsPage.IsUniqueDisplayed());
            TestContext.WriteLine($"Страница: Инвестиции, тип локатора: XPath, значение локатора: //span[text() = 'Инвестиции в акции, облигации и валюту']");
        }
    }
}
