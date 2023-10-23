using System;

namespace ProjectManagement.Models.Request
{
    public class CompanyRequest
    {

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string CorporateName { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public string UserId { get; set; }

    }
}
