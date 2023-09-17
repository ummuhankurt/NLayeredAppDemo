using Autofac;
using Autofac.Core;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Autofac
{
    public class InstanceFactory
    {
        private static IContainer Container;
        static InstanceFactory()
        {
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            Container = builder.Build();
        }
        public static T GetInstance<T>()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }

        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
        }

    }
}
