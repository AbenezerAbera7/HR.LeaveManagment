using HR.LeaveManagment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence
{
    public class LeaveManagmentDbContextFactory : IDesignTimeDbContextFactory<LeaveManagmentDbContext>
    {
        public LeaveManagmentDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var builder = new DbContextOptionsBuilder<LeaveManagmentDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagmentConnectionString");

            builder.UseSqlServer(connectionString);

            return new LeaveManagmentDbContext(builder.Options);
        }
    }
}
