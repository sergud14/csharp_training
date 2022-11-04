using NUnit.Framework;
using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [TestFixture]
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

        static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        { 
          int l=Convert.ToInt32(rnd.Next(max)*max);  
          StringBuilder builder=new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

        static Random gen = new Random();
        public static string RandomDay()
        {
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            Thread.CurrentThread.CurrentCulture=new System.Globalization.CultureInfo("en-GB");
            string day = start.AddDays(gen.Next(range)).ToLongDateString();
            day=day.Substring(0,2).Trim();
            day=Regex.Replace(day, "[0]", "");
            return day;
        }

        public static string RandomMonth()
        {
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            string month = start.AddDays(gen.Next(range)).ToLongDateString();
            month = month.Substring(3, month.Length - 3).Trim();
            month = Regex.Replace(month, "[ 0-9]", "");
            return month;
        }
        public static string RandomYear()
        {
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            string year = start.AddDays(gen.Next(range)).ToLongDateString();
            year = year.Substring(year.Length-4, 4).Trim();
            return year;
        }


    }
}
