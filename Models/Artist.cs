using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Rythmm.Models;

namespace Rythmm.Models
{
    public class Artist
    {
        //the primary key for the artists.
        public int Id { get; set; }

        //the name of the artist is required.
        [Required]
        //the maximum length the artists name can be is 100 characters.
        [StringLength(100)]
        //the name of the artist.
        public string Name { get; set; }

        //the nationality of the artist.
        public Nationality Nationality { get; set; }
        //the Id of the nationality.
        public byte NationalityId { get; set; }
    }
}