using Blog.BusinessLogic.Abstract;
using Blog.BusinessLogic.Concrete;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Blog.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogContext>();
            serviceCollection.AddIdentity<User, Role>().AddEntityFrameworkStores<SecurityContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            return serviceCollection;
        }
    }
}
