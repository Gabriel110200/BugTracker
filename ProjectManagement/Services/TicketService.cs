using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectManagement.IServices;

namespace ProjectManagement.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;

        }

        public TicketService()
        {

        }

        public async override Task<bool> Create(Ticket ticket)
        {

            if (this._context.Tickets.Any(x => x.Title == ticket.Title))
                throw new Exception("Feature já registrada");


            this._context.Tickets.Add(ticket);

            await this._context.SaveChangesAsync();

            return true;



        }


        public override  double UrgentPriorityArithmeticMean(Project project)
        {

            var tickets = project.Tickets;

            var ActiveTickets = this._context.Tickets.Where(x => x.ProjectId_FK == project.Id && x.Status == Enum.TicketStatusEnum.Ready);

            var urgentPriorityTicketsNumber = 0.0;


            Dictionary<string, double> dict = new Dictionary<string, double>();


            for (var i = 0; i < tickets.Count; i++)
            {

                if (tickets[i].Priority == Enum.TicketPriority.Urgent && tickets[i].Type == Enum.TicketTypeEnum.Feature)
                {
                    urgentPriorityTicketsNumber++;

                }


            }


            var urgentMean = urgentPriorityTicketsNumber / tickets.Count;



            return urgentMean;

        }

        public bool Delete(Guid guid)
        {

            var ticket = this._context.Tickets.Where(x => x.Id == guid).FirstOrDefault();

            if (ticket == null)
                return false;

            this._context.Tickets.Remove(ticket);
            this._context.SaveChangesAsync();

            return true;
        }
    }
}
