﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly2.Dtos;

namespace Vidly2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        
        [Display(Name="Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }

    }
}