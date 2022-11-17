using eMovies.Data;
using eMovies.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public int Year { get; set; }
        public int Quantity { get; set; } 
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Movie_Actor> Movies_Actors { get; set; }

        //Media
        public int MediaId { get; set; }
        [ForeignKey("MediaId")]
        public Media Media { get; set; }

        //Director
        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }


    }
}
