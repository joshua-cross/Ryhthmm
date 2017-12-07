using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rythmm.Models
{
    public class Genre
    {
        //primary key for the Id.
        public int Id { get; set; }
        //the name of the genre is required.
        [Required]
        //the maximum length of the genre is 50.
        [StringLength(50)]
        //the name of the genre.
        public string Name { get; set; }
    }
}