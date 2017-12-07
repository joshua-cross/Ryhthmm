using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//NEED THIS FOR _CONTEXT!
using Rythmm.Models;
using Rythmm.ViewModels;

namespace Rythmm.Controllers
{
    public class SongController : Controller
    {

        private ApplicationDbContext _context;

        //constructor.
        public SongController()
        {
            _context = new ApplicationDbContext();
        }

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]

        // GET: Song
        [Route("Song")]
        public ActionResult Index()
        {
            var songs = _context.Song.ToList();

            return View(songs);
        }

        public ActionResult New()
        {
            //getting the genres from the database.
            var genres = _context.Genres.ToList();
            var artists = _context.Artist.ToList();
            var albums = _context.Album.ToList();

            var viewModel = new SongFormViewModel
            {
                Genres = genres,
                Artists = artists,
                Albums = albums,
                Song = new Song()
            };
            
            
            return View("SongForm", viewModel);
        }

        //only be able to access to the save feature with the save button.
        [HttpPost]
        //implementing the anti-forgery
        [ValidateAntiForgeryToken]
        //Save fucntion that saves what was entered in a form to the database.
        public ActionResult Save(SongFormViewModel viewModel)
        {
            var song = viewModel.Song;

            if(!ModelState.IsValid)
            {
                var artists = _context.Artist.ToList();
                var albums = _context.Album.ToList();
                var genres = _context.Genres.ToList();

                var thisViewModel = new SongFormViewModel
                {
                    Song = song,
                    Albums = albums,
                    Genres = genres,
                    Artists = artists
                };

                return View("SongForm", thisViewModel);
            }

            return Content("Added.");
        }

        //disposing the _context.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}