﻿using System;

namespace MovieStore.Core.Entities
{
    public class Review
    {
        public Review()
        {
        }

        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
        public virtual User User { get; set; }
        public Movie Movie { get; set; }
    }
}
