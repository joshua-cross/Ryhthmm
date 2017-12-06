using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rythmm.Models;
using System.Data.Entity;
using Rythmm.ViewModels;

namespace Rythmm.Controllers
{
    public class ArtistController : Controller
    {
        private ApplicationDbContext _context;

        //constructor
        public ArtistController ()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        //Action that is called when we want to create a new artist.
        public ActionResult New()
        {
            //the list of nationalities from the database.
            var nationalities = _context.Nationalities.ToList();

            //creating a viewModel for the ArtistForm page.
            var viewModel = new ArtistFormViewModel()
            {
                Nationalities = nationalities,
                Artist = new Artist()
            };
            //returning the ArtistForm view.
            return View("ArtistForm", viewModel);
        }

        //disposing of the context.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}