using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moment3.Models
{
    public class Album
    {
        public int AlbumId { get; set; } // Primary key for Album
        

        public int ArtistId { get; set; } // Foreign key to Artist
        public Artist Artist { get; set; }
        
        public string Title { get; set; }

        [Display(Name = "Release Year")]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Amount of songs")]
        public int AmountOfSongs { get; set; }

        [Display(Name = "Play Time (min)")]
        public double PlayTime { get; set; }

    }
}

