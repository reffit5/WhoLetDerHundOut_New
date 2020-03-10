using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    [Table("DogInfo")]
    public class Dog
    {
        [Key]
        public int DogId { get; set; }

        [Required(ErrorMessage = "Please enter the student's last name.")]

        [Display(Name = "Users Id")]
        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "The nick name must be less than {1} characters")]
        [Column("NickName")]
        [Display(Name = "Nick Name")]
        public string nickName { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public int BreedId { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
        //public virtual ICollection<Dog> Dogs { get; set; }
        public virtual Users Users { get; set; }
    }
}