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


        public override Dictionary<string, double> UrgentPriorityArithmeticMean(Project project)
        {

            var tickets = project.Tickets;

            var ActiveTickets = this._context.Tickets.Where(x => x.ProjectId_FK == project.Id && x.Status == Enum.TicketStatusEnum.Ready);

            var urgentPriorityTicketsNumber = 0.0;
            var highPriorityTicketsNumber = 0.0;
            var mediumPriorityTicketsNumber = 0.0;
            var lowPriorityTicketsNumber = 0.0;

            Dictionary<string, double> dict = new Dictionary<string, double>();


            for (var i = 0; i < tickets.Count; i++)
            {

                if (tickets[i].Priority == Enum.TicketPriority.Urgent)
                {
                    urgentPriorityTicketsNumber++;

                }

                if (tickets[i].Priority == Enum.TicketPriority.High)
                {
                    highPriorityTicketsNumber++;

                }

                if (tickets[i].Priority == Enum.TicketPriority.Medium)
                {
                    mediumPriorityTicketsNumber++;
                }


                if (tickets[i].Priority == Enum.TicketPriority.Low)
                {
                    lowPriorityTicketsNumber++;
                }

            }


            var urgentMean = urgentPriorityTicketsNumber / tickets.Count;
            var highMean = highPriorityTicketsNumber / tickets.Count;
            var mediumMean = mediumPriorityTicketsNumber / tickets.Count;
            var lowMean = lowPriorityTicketsNumber / tickets.Count;

            dict.Add("Urgentes", urgentMean);
            dict.Add("Alta prioridade", urgentMean);
            dict.Add("Média prioridade ", urgentMean);
            dict.Add("Baixa prioridade", urgentMean);


            return dict;

        }


    }
}
