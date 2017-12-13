using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rythmm.Models;

namespace Rythmm.ViewModels
{
    public class AlbumIndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
    }
}