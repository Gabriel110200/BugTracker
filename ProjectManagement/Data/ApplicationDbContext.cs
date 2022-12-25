using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Map;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Company> Companies { get; set; }

      //  public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }  

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCompany> userCompanies { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CompanyMap).Assembly);
            base.OnModelCreating(builder);
        }



    }
}
