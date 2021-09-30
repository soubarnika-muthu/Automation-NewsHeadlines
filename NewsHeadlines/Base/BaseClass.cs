
/*Project:Assignment to list all webelements and perform some operations in NewsHeadlines website
 *Author: Soubarnika Muthu V
 *Date: 25/09/2021
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace NewsHeadlines.Base
{
    public class BaseClass
    {
        //initialization
        public static IWebDriver driver;
       
        [SetUp]
        public void SetUp()
        {
           
            try
            {
                //creating object of chromeoption class
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                //Creating an instance webdriver
                driver = new ChromeDriver(options);
                //navigating to url
                driver.Url = "https://news.ycombinator.com/news";
                // To maximize browser
                driver.Manage().Window.Maximize();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

     
        [TearDown]
        public void TearDown()
        {
            //closing the browser
            driver.Quit();
        }
    }
}

