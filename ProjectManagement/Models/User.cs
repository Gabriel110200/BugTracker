using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class User : IdentityUser<Guid>
    {

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<UserCompany> UserCompany { get; set; }

        public string Password { get; set; }





    }
}
