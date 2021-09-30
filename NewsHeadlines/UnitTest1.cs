
/*Project:Assignment to list all webelements and perform some operations in NewsHeadlines website
 *Author: Soubarnika Muthu V
 *Date: 25/09/2021
 */
using NUnit.Framework;

namespace NewsHeadlines
{
    public class Tests:Base.BaseClass
    {

       
        [Test]
        public void Test_DisplayRecords()
        {
            Action.DoAction display = new Action.DoAction();
            display.DisplayTitle();
            display.DisplayScore();
            display.Display_Records();


        }
    }
}