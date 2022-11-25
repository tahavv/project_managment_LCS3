using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class tasks
    {
        [Key]
        public int taskId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string workflow { get; set; }
        public string type { get; set; }

        //Relationships
        public int projectId { get; set; }
        [ForeignKey("projectId")]
        public project project { get; set; }

        public String userId { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser user { get; set; }
    }
}