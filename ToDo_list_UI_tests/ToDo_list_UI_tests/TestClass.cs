using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo_list_UI_tests
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void Test_001()
        {
            driver.Navigate().GoToUrl(new Uri(@"index.jpg", UriKind.Relative));
            Thread.Sleep(3000);
        }
    }
}
