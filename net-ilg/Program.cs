using App;
using Autofac;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ilg
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReportService>();
            builder.RegisterType<FileRepository>().As<IDataRepository>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<ReportService>();
                writer.GenerateReport();
            }
        }
    }
}
