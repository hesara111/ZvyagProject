using Autofac;
using Autofac.Integration.Mvc;
using Project.SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Builder;
using Project.SQLDataAccess.Repositories;
using Project.Core.Stuff;
using Project.SQLDataAccess.Entities;
using Project.BuisnessLogic.Manage;

namespace Project.Inject
{
        public class Injection
        {
            public static void Inject()
            {
                ProjectDbContext context = new ProjectDbContext();
                var builder = new ContainerBuilder();

                builder.RegisterControllers(typeof(MvcApplication).Assembly);
                builder.Register(c => new Repository<Objective, Guid>(context)).As<IRepository<Objective, Guid>>();
                builder.Register(c => new Repository<Account, Guid>(context)).As<IRepository<Account, Guid>>();
                builder.Register(c => new AccountRepository<Account>(context)).As<IAccountRepository<Account>>();
                builder.Register(c => new Manager<Objective, Guid>(new Repository<Objective, Guid>(context))).As<IManager<Objective, Guid>>();
                builder.Register(c => new Manager<Account, Guid>(new Repository<Account, Guid>(context))).As<IManager<Account, Guid>>();
                builder.Register(c => new AccountManager<Account>(new AccountRepository<Account>(context))).As<IAccountManager<Account>>();
                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
    }
}