using eMovies.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; 
using System.Threading.Tasks;

namespace eMovies.Models
{
    public class Director : IEntityBase
    {  
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Information")]
        [Required(ErrorMessage = "Information is required")]
        public string Info { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
