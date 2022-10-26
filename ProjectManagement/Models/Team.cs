using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Team
    {
        public string Name { get; set; }

        public Enum Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<IdentityUser> Users { get; set; }

      

    }
}
