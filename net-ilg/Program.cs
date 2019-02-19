using App;
using Autofac;
using System;

namespace net_ilg
{
    class Program
    {       
        static void Main(string[] args)
        {
            DependencyInjection.CreateContainer();

            using (var scope = DependencyInjection.Container.BeginLifetimeScope())
            {
                var reportService = scope.Resolve<ReportService>();

                Console.WriteLine("generating report...");

                reportService.GenerateReport();

                Console.WriteLine("report generated successfully! press any key to continue ...");
                Console.ReadLine();

            }
        }
    }
}
