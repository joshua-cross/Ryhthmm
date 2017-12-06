using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rythmm.Models;

namespace Rythmm.ViewModels
{
    public class ArtistFormViewModel
    {
        //list of nationlaities for the drop down box.
        public IEnumerable<Nationality> Nationalities { get; set; }

        public Artist Artist { get; set; }
    }
}