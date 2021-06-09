using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen1 = new Citizen();
            Citizen citizen2 = new Citizen();

            citizen1.See("report1");
            Console.WriteLine(citizen1.Report.idReport);

      

            citizen2.See("report2");
            Console.WriteLine(citizen2.Report.idReport);
            Console.ReadLine();
        }
    }

    class Citizen
    {
        public Report Report { get; set; }
        public void See(string idReport)
        {
            Report = Report.getInstance(idReport);
        }
    }

    class Report
    {
        private static Report instance;
        public string idReport { get; private set; }
        private static object syncRoot = new object();

        protected Report(string id)
        {
            idReport = id;
        }

        public static Report getInstance(string id)
        {
            if (instance == null)
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Report(id);
                }
            return instance;
        }
    }
}