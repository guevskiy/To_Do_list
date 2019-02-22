using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace ToDo_list_UI_tests
{
    class TestsWaitUntil
    {
        WebDriverWait wait;
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void SetUp()
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("file:///E:/Repositoryes/To_Do_list/add_rows.html");
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Size = new Size(1920, 1080);
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        //-----------------------------------------------

        public void IsAlertCreated()
        {
           
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(8)]
        public void Test_wait_until_001(int nn)
        {
            wait.Until((IWebDriver dr) => dr.FindElements(By.CssSelector(".alert")).Count == nn);
            Console.WriteLine("Дождался! ))) Элементов " + nn + "!");
            driver.Navigate().Refresh();
        }


    }
}
