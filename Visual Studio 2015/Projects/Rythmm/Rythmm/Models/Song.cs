using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Rythmm.Models;

namespace Rythmm.Models
{
    public class Song
    {
        //The Name field will be required.
        [Required]
        //the maximum length this string can be is 255 characters.
        [StringLength(255)]
        //the name of the song
        public string Name { get; set; }

        //will be the primary key
        public byte Id { get; set; }

        //The artist of the song.
        public Artist Artist { get; set; }

        //the id of the artist.
        public byte ArtistId { get; set; }

        //the genre of the song.
        public Genre Genre { get; set; }

        //the id of the genre.
        public byte GenreId { get; set; }

        //the date in which the song was released.
        public DateTime Released { get; set; }

        public string Description { get; set; }
    }
}