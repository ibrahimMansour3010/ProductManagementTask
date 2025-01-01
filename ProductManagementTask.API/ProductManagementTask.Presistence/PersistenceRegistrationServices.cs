using ProductManagementTask.Applications.Common.Interfaces;
using ProductManagementTask.Presistence.Repositories.GenericRepo;
using ProductManagementTask.Presistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Presistence
{
    public static class PersistenceRegistrationServices
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkImplementaion>();
            services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));

            return services;
        }
    }
}
