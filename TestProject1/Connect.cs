using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class Connect
    {

        ApplicationDbContext context = null;


        public ApplicationDbContext CriarContextInMemory()
        {


            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("teste");


            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Debug);

            });

       
            builder.UseLoggerFactory(loggerFactory);

            this.context = new ApplicationDbContextTest(builder.Options);
            return this.context;


        }

    }
}
