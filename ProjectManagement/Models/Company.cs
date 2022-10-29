using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public List<Team>? Teams { get; set; }


    }
}
