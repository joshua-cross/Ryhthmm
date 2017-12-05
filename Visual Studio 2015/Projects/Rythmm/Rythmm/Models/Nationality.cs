using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Rythmm.Models
{
    public class Nationality
    {
        //the id of the nationality (primary key)
        public byte Id { get; set; }

        //the name of the nationality is required.
        [Required]
        //the maximum length of this nationality is 50 characters
        [StringLength(100)]
        //the name of the nationality.
        public string Name { get; set; }
    }
}