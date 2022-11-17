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
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Movie name")]
        public string Name { get; set; }
               
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Movie description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie poster is required")]
        [Display(Name = "Movie poster")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Release year is required")]
        [Display(Name = "Release year")] 
        public int Year { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")] 
        public int Quantity { get; set; }
       
        [Required(ErrorMessage = "Movie category is required")]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Required(ErrorMessage = "Movie actor(s) is required")]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Media is required")]
        [Display(Name = "Select media")]
        public int MediaId { get; set; }

        [Required(ErrorMessage = "Movie director is required")]
        [Display(Name = "Select director")]
        public int DirectorId { get; set; }
         


    }
}
