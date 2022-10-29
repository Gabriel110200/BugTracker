using System;

namespace ProjectManagement.Models
{
    public class Ticket
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        //public Enum Priority { get; set; }

        //public Enum Status { get; set; }


        //public Enum Type { get; set; }


        public string Message { get; set; }

        public DateTime DeadLine { get; set; }


        public Guid ProjectId_FK { get; set; }


        Project Project { get; set; }




    }
}
