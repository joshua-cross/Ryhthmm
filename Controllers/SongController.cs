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

            //getting all the albums from the database.
            var albumsDB = _context.Album.ToList();

            //getting all the artists from the database.
            var artistsDB = _context.Artist.ToList();

            //boolean that checks if the album is in the array or not.
            bool newAlbum = true;

            /*
            //looping through each of the albums in the array.
            foreach(Album album in albums)
            {
                //checking if the name of the album in the array is the same as the name that may have been entered.
                if(album.Name == song.Album.Name)
                {

                }
            }
            */

            //if the album Id is 0 that means nothing was selected from the drop down menu.
            if(viewModel.Song.AlbumId == 0)
            {
                if(song.Album.Name == null)
                {
                    Console.WriteLine("Please enter a value");
                } else
                {
                    //if the name of the 
                    if(song.ArtistId != null)
                    {

                    }
                    Console.WriteLine("The new album name was: " + song.Album.Name);
                }
            }
            //else something was selected from the drop down meny so we set the album name to be the Id of what was selected.
            else
            {
                Console.WriteLine("The album " + albumsDB[song.AlbumId] + " already exists.");
            }

            

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