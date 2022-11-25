using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class project : IEnumerable
    {
        [Key]
        public int projectId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime endDate { get; set; }


        //Relationships
        public List<tasks> tasks { get; set; }
        public virtual String userId { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser user { get; set; }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}