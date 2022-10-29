using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId_FK { get; set; }


        public Company Company { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeadLine { get; set; }

        public Guid TeamId_FK { get; set; }

        public List<Team> Team { get; set; }



    }
}
