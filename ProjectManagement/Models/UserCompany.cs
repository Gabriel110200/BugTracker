using System;

namespace ProjectManagement.Models
{
    public class UserCompany
    {

        public Guid DDD { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }




    }
}
