using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Data
{
    public enum MovieCategory
    {
        Action = 1,
        Cartoon,
        Comedy,
        Crime,
        Drama,
        Documentary,        
        Horror,
        Mystery,
        Thriller
    }
}
