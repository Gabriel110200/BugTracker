using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Repositories;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class TicketFeatureService : ITicketService
    {
        public ITicketRepository _ticketRepository { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public TicketFeatureService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            this._ticketRepository = this.UnitOfWork.GetTicketRepository();
        }


        public override async Task<bool> Create(Ticket ticket)
        {
            var doubleTicket = await this._ticketRepository.GetAsync(filter: x => x.Title == ticket.Title);

            //if (this._context.Tickets.Any(x => x.Title == ticket.Title))
            //    throw new Exception("Feature já registrada");

            if (doubleTicket == null)
                throw new Exception("Feature já registrada");

            await this._ticketRepository.AddAsync(ticket);

            await this.UnitOfWork.Commit();

            return true;
        }

        public override double UrgentPriorityArithmeticMean(Project project)
        {
            throw new System.NotImplementedException();
        }
    }
}
