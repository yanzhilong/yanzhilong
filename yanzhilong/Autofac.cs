using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Repository;
using yanzhilong.Service;

namespace yanzhilong
{
    public class Autofac
    {
        public static IContainer Container { get; set; }

        public static ILifetimeScope Scope
        {
            get
            {
                return Container.BeginLifetimeScope();
            }
        }

        public static void Application_Start()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            // 注册所有的MVC Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterAll(builder);

            //把容器装入到微软默认的依赖注入容器中
            Container = builder.Build();

            //MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));


        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterAll(ContainerBuilder builder)
        {

            // 注册类型，每次创建一个新的实例(不写默认就是这个)
            //builder.RegisterType<SomeType>().As<IService>().InstancePerDependency();

            // 注册类型,单例模式，只创建一个实例
            //builder.RegisterType<SomeType>().As<IService>().SingleInstance();

            // 注册类型,生命周期模式，每个生命周期每次创建一个新的实例
            //builder.RegisterType<SomeType>().As<IService>().InstancePerLifetimeScope();

            //泛型注册
            //builder.RegisterGeneric(typeof(NHibernateRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope()

            //手动注入，需要已经注入的值 
            //builder.Register(c => new LogManager(DateTime.Now, c.Resolve<IService>)).As<ILogger>();

            //注册实体
            //builder.RegisterType<TaskController>();

            //手动注入单例
            //builder.RegisterInstance(new TaskRepository()).As<ITaskRepository>();

            //手动注入，每次创建一个新的实例
            //builder.Register(new TaskRepository()).As<ITaskRepository>();

            builder.RegisterGeneric(typeof(MbRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<UserService>().InstancePerLifetimeScope(); ;

            builder.RegisterType<ArticleService>();
            builder.RegisterType<CategoryService>();
            builder.RegisterType<FilePersistenceService>();
            builder.RegisterType<UploadFileService>();
            builder.RegisterType<MakeTbItemService>();
            builder.RegisterType<MemoryCacheService>();
            builder.RegisterType<SxColorServiceMB>();
            builder.RegisterType<SxImageServiceMB>();
            builder.RegisterType<SxMainImageServiceMB>();
            builder.RegisterType<SxPropertyServiceMB>();
            builder.RegisterType<SxShoeServiceMB>();
            builder.RegisterType<SxSsizeServiceMB>();
            builder.RegisterType<TbItemService>();
            builder.RegisterType<TbPropertyCategoryService>();
            builder.RegisterType<TbPropertyMappingService>();
            builder.RegisterType<TbPropertyService>();
            builder.RegisterType<UserService>();
            builder.RegisterType<ViewTotalService>();


            builder.RegisterType<RoleServiceMB>();
            builder.RegisterType<RolePermissionRecordServiceMB>();
            builder.RegisterType<UserRoleServiceMB>();
            builder.RegisterType<PermissionRecordServiceMB>();

            builder.RegisterType<PermissionService>();
            builder.RegisterType<UserAuthService>();
                        
            builder.RegisterType<MemoryCacheService>().As<ICacheService>().Named<ICacheService>("MemoryCacheService").SingleInstance();

        }
    }
}