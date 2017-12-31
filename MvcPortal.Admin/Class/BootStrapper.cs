using Autofac;
using Autofac.Integration.Mvc;
using MvcPortal.Core.Infrastracture;
using MvcPortal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortal.Admin.Class
{
    public class BootStrapper
    {
        //Boot Aşamasında Çalışacak

        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();

            /* Bu Alan İçerisine interfaceler Register Edilir. Autofac kullandığımız için bu sayfa ve methodu yazdık. */

            builder.RegisterType<YaziRepository>().As<IYaziRepository>();
            builder.RegisterType<ResimRepository>().As<IResimRepository>();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}