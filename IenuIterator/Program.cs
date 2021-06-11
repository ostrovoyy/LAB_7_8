using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportItem[] rIt1 = new ReportItem[]
            {
                new ReportItem(){District="Kherson",Damage=700},
                new ReportItem(){District="Kherson",Damage=1222},
                new ReportItem(){District="Kherson",Damage=12290},
            };
            ReportItem[] rIt2 = new ReportItem[]
            {
                new ReportItem(){District="Kyiv",Damage=30},
                new ReportItem(){District="Kyiv",Damage=45000},
            };
            Report report = new Report(rIt1,rIt2);
            Client client = new Client();
            client.SeeReportItems(report);

            Console.ReadLine();
        }
    }

    class Client
    {
        public void SeeReportItems(Report report)
        {
            IDistrictIterator iterator = report.CreateNumerator();
            while (iterator.HasNext())
            {
                District district = iterator.Next();
                Console.WriteLine("\n"+district.Name);
                IReportItemIterator iterator1 = district.CreateNumerator();
                while (iterator1.HasNext())
                {
                    ReportItem reportItem = iterator1.Next();
                    Console.WriteLine(reportItem.District + ", price: " + reportItem.Damage);
                }
            } 
        }
    }
    interface IReportItemIterator
    {
        bool HasNext();
        ReprotItem Next();
    }
    interface IReportItemNumerable
    {
        IReportItemIterator CreateNumerator();
        int Count { get; }
        ReportItem this[int index] { get; }
    }

    interface IDistrictIterator
    {
        bool HasNext();
        District Next();
    }
    interface IDistrictNumerable
    {
        IDistrictIterator CreateNumerator();
        int Count { get; }
        District this[int index] { get; }
    }

    class ReportItem
    {
        public string District { get; set; }
        public int Damage { get; set; }
    }

    class District : IReportItemNumerable
    {
        public string Name { get; set; }
        private ReportItem[] reportItems;

        public District(string name, ReportItem[] reportIt)
        {
            Name = name;
            reportItems = new ReportItem[reportIt.Length];
            for (int i = 0; i < reportIt.Length; i++)
                reportItems[i] = reportIt[i];
        }
        public int Count
        {
            get { return reportItems.Length; }
        }
        public ReportItem this[int index]
        {
            get { return reportItems[index]; }
        }
        public IReportItemIterator CreateNumerator()
        {
            return new DistrictNumerator(this);
        }
    }

    class DistrictNumerator : IReportItemIterator
    {
        IReportItemNumerable aggregate;
        int index = 0;
        public DistrictNumerator(IReportItemNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public ReportItem Next()
        {
            return aggregate[index++];
        }
    }

    class Report : IDistrictNumerable
    {
        public District[] District;
        public Report(ReportItem[] rIt1, ReportItem[] rIt2)
        {
            District = new District[]
            {
                    new District("Kherson",rIt1),
                    new District("Kyiv",rIt2)
            };
        }
        public int Count
        {
            get { return Districts.Length; }
        }
        public District this[int index]
        {
            get { return Districts[index]; }
        }
        public IDistrictIterator CreateNumerator()
        {
            return new ReportNumerator(this);
        }
    }

    class ReportNumerator : IDistrictIterator
    {
        IDistrictNumerable aggregate;
        int index = 0;
        public ReportNumerator(IDistrictNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public District Next()
        {
            return aggregate[index++];
        }
    }
}
