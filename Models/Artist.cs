using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moment3.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        public List<Album> Albums { get; set; }
    }
}