﻿using System;
namespace MovieStore.Core.Entities
{
    public class Trailer
    {
        public Trailer()
        {
        }

        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        // If some one gave you Trailer Id and you wanna find that Movie details, then this property will be useful
        // Navigation property
        public Movie Movie { get; set; }
    }
}
