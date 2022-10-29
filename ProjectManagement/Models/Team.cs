using Microsoft.AspNetCore.Identity;
using ProjectManagement.Enum;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TeamEnumRating Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CompletedProjects { get; set; }

        public int LateProjects { get; set; }

        public int UndoneProjects { get; set; }

        public List<IdentityUser> Users { get; set; }

        public Guid CompanyId_FK { get; set; }

        public Company Company { get; set; }

        public Guid ProjectId_FK { get; set; }

        public Project AssignedProject { get; set; }

    }
}
