using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rythmm.Models
{
    public class NoSpecialCharacters : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var song = (Song)validationContext.ObjectInstance;

            //if the song contains a character it's not allowed to have then we will return an error message.
            if(song.Name.ToLower().Contains("/")
                || song.Name.ToLower().Contains("'"))
            {
                return new ValidationResult("Song cannot contain / or a '.");
            }

            return ValidationResult.Success;
            
            //return base.IsValid(value, validationContext);
        }
    }
}