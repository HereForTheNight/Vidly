﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte MovieGenreId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}