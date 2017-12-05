using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Rythmm.Models
{
    public class Album
    {
        //the iD of the Album.
        public byte Id { get; set; }

        //the name of the album is required.
        [Required]
        //the name of the album must be less than 100.
        [StringLength(100)]
        //the name of the album.
        public string Name { get; set; }

        //the artist which released the album.
        public Artist Artist { get; set; }
    }
}