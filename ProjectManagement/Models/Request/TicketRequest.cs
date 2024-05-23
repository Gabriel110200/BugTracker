using ProjectManagement.Enum;
using System;

namespace ProjectManagement.Models.Request
{
    public class TicketRequest
    {

        public string Title {  get; set; }


        public TicketPriority Priority { get; set; }

        public TicketStatusEnum Status { get; set; }


        public TicketTypeEnum Type { get; set; }


        public string Message { get; set; }

        public DateTime DeadLine { get; set; }


        public Guid ProjectId_FK { get; set; }


    }
}
