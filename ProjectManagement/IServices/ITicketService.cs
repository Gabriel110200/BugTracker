using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjectManagement.Models;

namespace ProjectManagement.IServices
{
    public abstract class ITicketService
    {

        public abstract Task<bool> Create(Ticket ticket);
       
        public abstract  double UrgentPriorityArithmeticMean(Project project);

    }
}
