﻿using App;
using Autofac;
using Infra;

namespace net_ilg
{
    public static class DependencyInjection
    {
        public static IContainer Container { get; set; }

        public static void CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReportService>();
            builder.RegisterType<FileRepository>().As<IDataRepository>();
            Container = builder.Build();
        }
    }
}