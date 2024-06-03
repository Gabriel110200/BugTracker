using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class TicketCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }


    }
}
