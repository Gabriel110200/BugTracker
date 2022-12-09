using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjectManagement.IServices;
using System.Linq;

namespace ProjectManagement.Services
{
    public class TicketBugService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketBugService(ApplicationDbContext context)
        {
            _context = context;

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
 




            for (var i = 0; i < tickets.Count; i++)
            {

                if (tickets[i].Priority == Enum.TicketPriority.Urgent && tickets[i].Type == Enum.TicketTypeEnum.Bug)
                {
                    urgentPriorityTicketsNumber++;

                }


            }


            var urgentMean = urgentPriorityTicketsNumber / tickets.Count;



            return urgentMean;

        }




    }
}
