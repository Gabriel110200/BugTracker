using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class ApplicationDbContextTest : ApplicationDbContext
    {
        public ApplicationDbContextTest(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
