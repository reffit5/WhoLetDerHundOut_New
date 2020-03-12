using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    public class Users
    {
        [StringLength(20, ErrorMessage = "The name must be less than {1} characters")]
        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int Id { get; set; }
        public int NumberofDogs  { get; set; }
        [Required]
        public int DogId { get; set; }
       
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}