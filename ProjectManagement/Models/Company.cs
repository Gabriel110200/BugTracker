using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string CorporateName { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public string UserId { get; set; }
        public IdentityUser Admin { get; set; }

        public List<Team>? Teams { get; set; }


    }
}
