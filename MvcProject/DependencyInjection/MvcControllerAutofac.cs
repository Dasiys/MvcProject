using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;

namespace MvcProject.DependencyInjection
{
    public static class MvcControllerAutofac
    {
        public static ContainerBuilder AddMvcControllers(this ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.Load("MvcProject"));
            return builder;
        }
    }
}