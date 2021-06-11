using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen = new Citizen();
            Report report = new Report();
            District district = new District();

            MakeReportFacade makeReport = new MakeReportFacade(citizen, report, district);
            Client client = new Client();
            client.MakeAnReport(makeReport);

            Console.ReadLine();
        }
    }

    class Citizen
    {
        public void AddCitizen()
        {
            Console.WriteLine("Add NewCitizen");
        }

        public void DeleteCitizen()
        {
            Console.WriteLine("Delete NewCitizen");
        }

        public void SaveCitizen()
        {
            Console.WriteLine("Save NewCitizen");
        }
    }

    class Report
    {
        public void PlaceRepotr()
        {
            Console.WriteLine("Place an Report");
        }
    }

    class District
    {
        public void SetDistrict()
        {
            Console.WriteLine("Choose District");
        }
    }

    class MakeReportFacade
    {
        Citizen citizen;
        Report report;
        District district;

        public MakeReportFacade(Citizen c, Report o, District p)
        {
            citizen = c;
            report = o;
            district = p;
        }

        public void MakeReport()
        {
            citizen.AddCitizen(c);
            citizen.SaveCitizen(c);
            report.PlaceRepotr(o);
            district.SetDistrict(p);
        }
    }

    class Client
    {
        public void MakeAnReport(MakeReportFacade facade)
        {
            facade.MakeReport();
        }
    }
}
