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

        [OneTimeSetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://myfirstsite2243.000webhostapp.com/To_Do_List/index.html");
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        //-----------------------------------------------



        public int GetCountOfitems()
        {
            return driver.FindElements(By.CssSelector(".todo__item")).Count;
        }

        public void Add_item(string text)
        {
            driver.FindElement(By.CssSelector("#todo-add-new")).SendKeys(text);
            driver.FindElement(By.CssSelector("#btn-submit")).Click();
        }

        public void Del_items()
        {
            driver.FindElement(By.CssSelector("#clear-todos")).Click();
        }

        public void Del_marked_items()
        {
            driver.FindElement(By.CssSelector("#btn-new")).Click();
        }

        public void MarkEvenItems()
        {
            var elems = driver.FindElements(By.CssSelector(".todo__item"));
            Console.WriteLine(elems.Count);
            for (int i = 0; i < elems.Count; i =i + 2)
            {
                elems[i].Click();
                Thread.Sleep(500);
            }
        }

        public void Create_items(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Add_item("12" + i);
                Thread.Sleep(500);
            }
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void Test_001(int exp)
        {
            Create_items(exp);

            Assert.AreEqual(exp, GetCountOfitems());
            Thread.Sleep(2000);
            Del_items();
        }


        [Test]
        public void Test_002()
        {
            Create_items(8);
            MarkEvenItems();

            Del_marked_items();
            Thread.Sleep(2000);

            Assert.AreEqual(4, GetCountOfitems());
            
            Del_items();
            Thread.Sleep(2000);
        }
    }
}
