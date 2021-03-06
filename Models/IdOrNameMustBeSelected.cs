﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//need this to create own custom requirement for the form.
using System.ComponentModel.DataAnnotations;
using Rythmm.Models;

namespace Rythmm.Models
{
    /*Creating a requirement that either the drop-down menu for the album must be selecter
     or the name must be filled out so we can create a album.*/
    public class IdOrNameMustBeSelected : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var song = (Song)validationContext.ObjectInstance;

            /*if the Id of the song (from the drop down menu) is 0 (unknown) and the
             name the user has entered is null or empty then the user has not entered
             an album so we should return the user an error telling them to fill
             one of the fields out.*/
            if (song.AlbumId == null && song.Album.Name == null)
            {
                return new ValidationResult("Please choose an album from either the drop down menu or "
                                    + "create a new album");
            }

            /*Else the user has created an album so we should return a success.*/
            else
            {
                if(song.AlbumId == null)
                {
                    song.AlbumId = 0;
                }

                if(song.Album.Name == null)
                {
                    song.Album.Name = "";
                }
                /*If the user has entered something in both the drop-down menu, and the text box
                 then we will return an error telling the user to just use one or the other.*/
                if((song.AlbumId.Value != 0 && song.AlbumId != null) &&
                    (song.Album.Name != "" && song.Album.Name != null))
                {
                    return new ValidationResult("Please select EITHER the drop down menu, or the text box for the abum.");
                }

                //else the user has done everything successfully so return a success.
                return ValidationResult.Success;
            }

            //return base.IsValid(value, validationContext);
        }
    }
}