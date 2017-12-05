using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//NEED THIS FOR _CONTEXT!
using Rythmm.Models;

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
            //var genres = _context.

            return View("SongForm");
        }

        //disposing the _context.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}