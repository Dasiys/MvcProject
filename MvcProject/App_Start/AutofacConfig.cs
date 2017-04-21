﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using DAL.DependencyInjection;
using DependencyInjection;
using MvcProject.DependencyInjection;

namespace MvcProject.App_Start
{
    public static class AutofacConfig
    {
        public static void Builder()
        {
            var builder = new ContainerBuilder();
            builder.RepositoryInjection();
            builder.UnitOfWorkInjection();
            builder.ApplicationInjection();
            builder.AddMvcControllers();
            var container = builder.Build();
            container.AddMvc5();
        }
    }
}