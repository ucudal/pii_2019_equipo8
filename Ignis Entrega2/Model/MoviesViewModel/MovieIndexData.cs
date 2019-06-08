using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ignis.Models.MoviesViewModel
{
    public class MovieIndexData
    {
        public IEnumerable<Movie> Movies { get; set; }

        public IEnumerable<Actor> Actors { get; set; }

        public IEnumerable<Appereance> Cast { get; set; }
    }
}