using System;

namespace ProjectManagement.Models.Request
{
    public class ProjectRequest
    {

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public Guid UserId {  get; set; }

        public string Image {  get; set; }

        public Guid CompanyID { get; set; }


    }
}
