using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rythmm.Models;

namespace Rythmm.ViewModels
{
    public class SongFormViewModel
    {
        //list of genres which will be used in the droo down menus.
        public IEnumerable<Genre> Genres { get; set; }

        //list of artists which will be used in the drop down menu.
        public IEnumerable<Artist> Artists { get; set; }

        //the song.
        public Song Song { get; set; }
    }
}