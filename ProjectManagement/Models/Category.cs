using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Category
    {
        public Guid Id { get; set; }    

        public string Name  { get; set; }


        public List<Project> Project { get; set; }

    }
}
