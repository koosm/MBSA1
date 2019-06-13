using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBSA.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
    }
}
