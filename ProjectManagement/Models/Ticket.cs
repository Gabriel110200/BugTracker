using ProjectManagement.Enum;
using System;

namespace ProjectManagement.Models
{
    public class Ticket
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Visibility { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketStatusEnum Status { get; set; }

        public TicketTypeEnum Type { get; set; }

        public string Description { get; set; }

        public string ObservableBehavior { get; set; }

        public string ExpectedBehavior { get; set; }

        public string StepsToReproduce { get; set; }

        public string File { get; set; }

        public DateTime  DeadLine { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid ProjectId_FK { get; set; }

        public Guid? TicketCategoryId_FK { get; set; }

        public TicketCategory Category { get; set; }

        Project Project { get; set; }

   
    }
}
