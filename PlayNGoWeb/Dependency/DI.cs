using Autofac;
using Autofac.Integration.Mvc;
using PlayNGo.Business.Interface;
using PlayNGo.Business.Service;
using PlayNGo.Core.Context;
using PlayNGo.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PlayNGoWeb.Dependency
{
    public class DI
    {
        public Autofac.IContainer myContainer { get; private set; }


        public void Configure()
        {

            ContainerBuilder builder = new ContainerBuilder();

            builder = OnConfigure(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            if (this.myContainer == null)
            {
                this.myContainer = builder.Build();
            }
            else
            {
                builder.Update(this.myContainer);
            }


            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.myContainer));

        }

        public ContainerBuilder OnConfigure(ContainerBuilder builder)
        {
            //This is where you register all dependencies

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            //The line below tells autofac, everytime an implementation IDAL is needed, pass in an instance of the class DAL

            //Context Injection
            builder.RegisterType<PlayNGoContext>().As<IContext>().InstancePerLifetimeScope();

            //Generic repository injection
            builder.RegisterGeneric(typeof(CoreRepository<>)).As(typeof(ICoreRepository<>)).InstancePerLifetimeScope();


            //Business Injection Service
            builder.RegisterType<EmployeeService>().As(typeof(IEmployeeService)).InstancePerLifetimeScope();

            return builder;



        }
    }
}