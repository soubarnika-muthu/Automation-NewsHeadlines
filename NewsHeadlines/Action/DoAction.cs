/*Project:Assignment to list all webelements and perform some operations in NewsHeadlines website
 *Author: Soubarnika Muthu V
 *Date: 25/09/2021
 */
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NewsHeadlines.Action
{
    public class DoAction : Base.BaseClass
    {
        //initialization of IWebElement
        public static IWebElement WebElement;
        //initialization of List
        List<int> list;
        List<string> list1;
        public DoAction()
        {
            list = new List<int>();
            list1 = new List<string>();
        }
        //method to display titles in NewsHeadlines Website 
        public void DisplayTitle()
        {
            try
            {
                //finding all titles and stored into list
                IList<IWebElement> news = driver.FindElements(By.CssSelector("a.storylink"));
                Console.WriteLine("***************Headlines******************");
                foreach (IWebElement topic in news)
                {
                    string headLines = topic.Text;

                    Console.WriteLine(headLines);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //method to display points in NewsHeadlines Website 
        public void DisplayScore()
        {
            try
            {
                //finding all Points and storing into list
                IList<IWebElement> score = driver.FindElements(By.XPath("//span[@class='score']"));
                Console.WriteLine("***********************Score*******************");
                foreach (IWebElement topic in score)
                {
                    string points = topic.Text;

                    Console.WriteLine(points);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        //method to display titles with score in NewsHeadlines Website 
        public void Display_Records()
        {
            try
            {
                //finding all headlines with score  and stored into list
                IList<IWebElement> records = driver.FindElements(By.XPath("//span[@class='score']|//td[@class='title']"));
                Console.WriteLine("***********************Headlines with Score*******************");
                foreach (IWebElement topic in records)
                {
                    string headlinescore = topic.Text;
                    Console.WriteLine(headlinescore);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //sorting points
        public void SortingPointWise()
        {
            try
            {
                foreach (var score in driver.FindElements(By.XPath("//span[@class='score']")))
                {
                    string records = score.Text;
                    // Splitting to find the word
                    string[] numbers = Regex.Split(records, @"\D+");
                    foreach (string value in numbers)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            int i = int.Parse(value);
                            list.Add(i);
                            Console.WriteLine("Headline points: {0}", i);
                        }
                    }
                }
                HighestData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void HighestData()
        {
            var res = list.OrderByDescending(g => g).Take(1);
            foreach (var g in res)
            {
                Console.WriteLine("Highest value:{0}", g);
            }
        }
        // Function to count frequency of words in the given list
        public void Count_Frequency()
        {
            try
            {
                //Using dictionary 
                SortedDictionary<String,
                                 int> mp = new SortedDictionary<String,
                                                                int>();
                String key = "";
                int value = 0;
                foreach (var headlines in driver.FindElements(By.CssSelector("a.storylink")))
                {
                    string records = headlines.Text;
                    // Splitting to find the word
                    string[] arr = records.Split(' ');
                    //Adding itmes into list
                    foreach (string arrItem in arr)
                    {
                        list1.Add(arrItem);
                    }
                }
                ////printing list
                //Console.WriteLine("Headlines");
                //for (int i = 0; i < list1.Count; i++)
                //{
                //    Console.WriteLine(list1[i]);
                //}

                // Loop to iterate over the words
                for (int i = 0; i < list1.Count; i++)
                {

                    // Condition to check if the
                    // array element is present
                    // the hash-map
                    if (mp.ContainsKey(list1[i]))
                    {
                        mp[list1[i]] = mp[list1[i]] + 1;
                    }
                    else
                    {
                        mp.Add(list1[i], 1);
                    }
                }
                Console.WriteLine("************Frequency of words****************");
                // Loop to iterate over the
                // elements of the map
                foreach (KeyValuePair<String, int> entry in mp)
                {
                    Console.WriteLine(entry.Key + " - " +
                                      entry.Value);
                    // Check for word having highest frequency
                    if (entry.Value > value)
                    {
                        value = entry.Value;
                        key = entry.Key;
                    }
                }

                //finding maxiumm value
                var maxValue = mp.Values.Max();

                Console.WriteLine("The most repeted word is :" + key);
                Console.WriteLine("No.of.Times:" + maxValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}

