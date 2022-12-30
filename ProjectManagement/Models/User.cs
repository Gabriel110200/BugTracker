using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class User : IdentityUser
    {


        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<UserCompany> UserCompany { get; set; }






    }
}
