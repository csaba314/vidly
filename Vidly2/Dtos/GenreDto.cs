using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Dtos
{
    // add a GenreDto class to supply Genre types to the /api/movies/
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}