using contactManagement.DAL.Implementations;
using contactManagement.DAL.Interfaces;
using contactManagement.DAL;
using contactManagement.Services.Implementations;
using contactManagement.Services.Interfaces;
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contactManagement.DomainModels.Entities;

namespace contactManagement.Services.Configuration
{
    public static class ConfigureDependencies
    {
        //public static void AddServices(IServiceCollection services, IConfiguration configuration)
        //public static void AddServices(IServiceCollection services)
        //{
        //    //services.AddDbContext<AppDbContext>((options) =>
        //    //{
        //    //    options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        //    //});


        //    services.AddScoped<DbContext, AppDbContext>();

        //    //Repositories
        //    services.AddTransient<IRepository<Contact>, Repository<Contact>>();

        //    //Services
        //    services.AddScoped<IService<Contact>, Service<Contact>>();
        //}
    }
}
