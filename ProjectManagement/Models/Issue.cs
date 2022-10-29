using System;

namespace ProjectManagement.Models
{
    public class Issue
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

      //  public Enum Urgency { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
