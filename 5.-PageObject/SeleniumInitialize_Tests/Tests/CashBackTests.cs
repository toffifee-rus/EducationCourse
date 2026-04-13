using SeleniumInitialize_Tests.Asserts;
using SeleniumInitialize_Tests.Data;
using SeleniumInitialize_Tests.Pages;

namespace SeleniumInitialize_Tests.Tests
{
    [TestFixture]
    public class CashBackTests : BaseTest
    {
        /// <summary>
        /// Модель для хранения данных
        /// </summary>
        private User _testUser;

        /// <summary>
        /// Генерируем случайные данные перед каждым запуском теста
        /// </summary>
        [SetUp]
        public void GeneretaData()
        {
            _testUser = new User
            {
                LastName = Generator.GenerateName(),
                FirstName = Generator.GenerateName(),
                MiddleName = Generator.GenerateName(),
                BirthDate = Generator.GenerateBirthDate(),
                Phone = Generator.GeneratePhone(),
                Gender = Generator.GenerateGender()
            };
        }

        [Test(Description = "Задание №1. Заполнение заявки случайными валидными данными")]
        public void FillRandomDataTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);

            cashBackPage.Open();
            cashBackPage.FillPage(_testUser);
        }

        [Test(Description = "Задание №2 Проверка данных из теста 1")]
        public void ValidateValuesTest()
        {
            CashBackPage cashBackPage = new CashBackPage(_driver);
            ValidateValues validateValues = new ValidateValues(_driver);

            cashBackPage.Open();
            cashBackPage.FillPage(_testUser);


            validateValues.DataAssert(_testUser);
        }

        [Test(Description = "Задание №3 Заполнение и проверка для страницы кредита")]
        public void FillAndValidateTest()
        {
            CreditPage creditPage = new CreditPage(_driver);
            ValidateValues validateValues = new ValidateValues(_driver);

            creditPage.Open();
            creditPage.FillPage(_testUser);

            validateValues.DataAssert(_testUser);
        }
    }
}