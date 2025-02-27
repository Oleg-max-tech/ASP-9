﻿using System.ComponentModel.DataAnnotations;

namespace MovieAppWithAuthors
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
