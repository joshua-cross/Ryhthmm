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

        //must be sent from HttpPost.
        [HttpPost]
        //give action an antiforgery token.
        [ValidateAntiForgeryToken]
        /*Action that will save the new/edited artist to the database.*/
        public ActionResult Save(Artist artist)
        {
            /*if what the user has entered is not correct, e.g. they have not entered a name
             then we will return them to the MovieForm.*/
            if(!ModelState.IsValid)
            {
                //re-creating the viewModel for the view.
                var viewModel = new ArtistFormViewModel
                {
                    Artist = artist,
                    Nationalities = _context.Nationalities.ToList()
                };

                return View("ArtistForm", viewModel);
            }
            //else we're going to add the artist to the database.
            else
            {
                //saving to the local memory.
                _context.Artist.Add(artist);
                //trying to save to the database.
                try
                {
                    _context.SaveChanges();
                }
                //catching the exception.
                catch (Exception error)
                {
                    return Content(error.ToString());
                }
            }


            return Content(artist.Name + "has been added to the database.");
        }

        //disposing of the context.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}