using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagmentDbContext>(Options =>Options
            .UseSqlServer(configuration.GetConnectionString("LeaveManagmentConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository> ();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository> ();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository> ();


            return services;
        }
    }
}
