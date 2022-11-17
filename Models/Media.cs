using eMovies.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Models
{
    public class Media : IEntityBase
    {
        [Key] 
        public int Id { get; set; }

        [Display(Name = "Media Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
