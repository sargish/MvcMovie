﻿using System;
//using System.ComponentModel.DataAnnotations;

namespace MyMovies.Client
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }        
        public string Rating { get; set; }
    }
}