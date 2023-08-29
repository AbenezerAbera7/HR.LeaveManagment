using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(

                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 1,
                    Name = "Name_one",
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 2,
                    Name = "Name_two",
                }

            );
        }
    }
}
