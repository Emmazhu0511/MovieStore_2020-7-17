﻿using System;
namespace MovieStore.MVC.Models
{
    public class Movie
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Budget { get; set; }

        public Movie()
        {
        }
    }
}
