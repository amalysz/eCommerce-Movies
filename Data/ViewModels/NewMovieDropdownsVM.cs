using eMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Directors = new List<Director>();
            Medias = new List<Media>();
            Actors = new List<Actor>();
        }

        public List<Director> Directors { get; set; }
        public List<Media> Medias { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
