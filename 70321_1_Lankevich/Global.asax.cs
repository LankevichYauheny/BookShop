using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;
using _70321_1_Lankevich.DAL.Repositories;


namespace _70321_1_Lankevich
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            //ValueProviderFactories.Factories.Add(new Binders.SessionValueProviderFactory());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            //kernel.Bind<IRepository<Book>>().To<FakeRepository>();
            kernel.Bind<IRepository<Book>>().To<EFBookRepository>();
            return kernel;
        }
    }
}
