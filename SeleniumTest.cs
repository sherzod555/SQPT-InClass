using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using UM.Services;

namespace TestProject1
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void LoginGITHUB()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/login");
            driver.Manage().Window.Maximize();

            //Login Input Box values
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[4]/form/input[2]")).SendKeys("00010035");  //4 points
            driver.FindElement(By.Id("password")).SendKeys("ibroxim7");  //4 points

            ////Sign In Button Click
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[4]/form/div/input[11]")).Click();    //1 point 


            ////click on Profile
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div[7]/details/summary/img")).Click(); //1 point

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/header/div[7]/details/details-menu/form/button")));


            // click on logout butotn
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div[7]/details/details-menu/form/button")).Click();

            driver.Close();
            driver.Quit();
        }
    }
}
