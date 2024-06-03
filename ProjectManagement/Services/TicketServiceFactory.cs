using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectManagement.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagement.Services
{
    public class TicketServiceFactory
    {

        private readonly IServiceProvider serviceProvider;

        public TicketServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public ITicketService GetTicketService(string ticketType)
        {
            switch (ticketType)
            {
                case "Bug":
                    return this.serviceProvider.GetService<TicketBugService>();
                case "Feature":
                    return this.serviceProvider.GetService<TicketFeatureService>();
                default:
                    throw new ArgumentException("Unsupported ticket type");
            }
        }

    }
}
