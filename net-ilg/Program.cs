using App;
using Autofac;

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
                reportService.GenerateReport();
            }
        }
    }
}
