using eMovies.Data.Base;
using eMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Data.Services
{
    public class MediasService : EntityBaseRepository<Media>, IMediasService
    {
        public MediasService(AppDbContext context) : base(context) { }
    }
}
