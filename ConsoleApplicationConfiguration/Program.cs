using ConsoleApplicationConfiguration.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ConsoleApplicationConfiguration
{
    class Program
    {
        public static int DateDiff_Days(DateTime dt1, DateTime dt2)
        {
            TimeSpan TS1 = new TimeSpan(dt1.Ticks);
            TimeSpan TS2 = new TimeSpan(dt2.Ticks);
            TimeSpan TS3 = TS1.Subtract(TS2);
            return TS3.Days;
        }
        static void Main(string[] args)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddDays(-2);
            int a = DateDiff_Days(dt2, dt1);
            //string a=Console.ReadLine();
            //switch (a)
            //{
            //    case "1":
            //        Console.WriteLine(1);
            //        break;
            //    case "2":
            //        Console.WriteLine(2);
            //        break;
            //    default :
            //        Console.WriteLine(a);
            //        break;
            //}
            //Console.ReadKey();

            //NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
            //string name = appSettings["name"];
            //appSettings.Add("w", "b");

            //Console.WriteLine(name);
            //Console.ReadKey();
            //read and update on exe.config not this app.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string DMSAPI_USER = config.AppSettings.Settings["DMSAPI_USER"].Value;
            string DMSAPI_PASSWORD = config.AppSettings.Settings["DMSAPI_Password"].Value;
            //Console.WriteLine(config.AppSettings.Settings["name"].Value);
            //config.AppSettings.Settings["name"].Value = "Chen";
            //Console.WriteLine(config.AppSettings.Settings["name"].Value);
            //Console.ReadKey();
            //app.Settings["name"].Value = "Zhao";

            //config.Save();
            //Console.WriteLine(config.AppSettings.Settings["name"].Value);
            //Console.ReadKey();
            //System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            IssueServiceClient obj = new IssueServiceClient();
            var aaa = obj.GetIssueForShiroyagiJira(DMSAPI_USER, DMSAPI_PASSWORD, "", "Convergence Jira", "");
            Console.ReadKey();
        }
    }
}
