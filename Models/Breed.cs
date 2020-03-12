using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    public class Breed
    {
         [Display (Name ="Breed ID")]
        public int BreedId { get; set; }
        [StringLength(20, ErrorMessage = "Breed Name cannot be longer than 20 characters")]
        [Display(Name = "Breed Name")]
        public string BreedName { get; set; }
        [StringLength(30, ErrorMessage = "Country cannot be longer than 30 characters")]
        public string Country { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}