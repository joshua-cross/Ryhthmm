using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rythmm.Models;

namespace Rythmm.ViewModels
{
    public class SongViewModel
    {        
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Genre> Genres{ get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}