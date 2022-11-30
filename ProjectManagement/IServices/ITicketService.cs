using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjectManagement.Models;

namespace ProjectManagement.IServices
{
    public abstract class ITicketService
    {

        //  Task<List<Ticket>> ListTickets();

        public abstract Task<bool> Create(Ticket ticket);
       

        //Task<bool> Update(Ticket ticket);

        //bool Delete(Guid id);

        public abstract Dictionary<string, double> UrgentPriorityArithmeticMean(Project project);




    }
}
