using System;

namespace ProjectManagement.Models
{
    public class Impediment
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid TicketId {  get; set; }

        public Ticket Ticket { get; set; }


    }
}
