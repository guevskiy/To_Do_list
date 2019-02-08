using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests4Jenkins
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://myfirstsite2243.000webhostapp.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void TestMethod_001()
        {
            string sz = driver.Manage().Window.Size.ToString();
            Console.WriteLine(sz);
            Assert.AreEqual("{Width=1936, Height=1056}", sz);
        }

        [Test]
        public void TestMethod_002()
        {
            driver.FindElement(By.CssSelector("li.mound.js-mound.penguin1")).Click();
            Thread.Sleep(3000);
        }



    }
}
