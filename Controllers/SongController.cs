using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//NEED THIS FOR _CONTEXT!
using Rythmm.Models;
using Rythmm.ViewModels;
//for the sqlstatement.
using System.Data.SqlClient;

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
            var genres = _context.Genres.ToList();
            var artists = _context.Artist.ToList();
            var albums = _context.Album.ToList();


            //creating a songViewModel which passes through the songs, the genres, the artists, and the albums.
            var viewController = new SongViewModel
            {
                Songs = songs,
                Genres = genres,
                Artists = artists,
                Albums = albums
            };


            return View(viewController);
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

            //getting all the songs from the database.
            var songs = _context.Song.ToList();

            //getting the genres from the database.
            var genres = _context.Genres.ToList();
            var artists = _context.Artist.ToList();
            var albums = _context.Album.ToList();

            //getting all the albums from the database.
            var albumsDB = _context.Album.ToList();

            //getting all the artists from the database.
            var artistsDB = _context.Artist.ToList();

            //boolean that checks if the album is in the array or not.
            bool newAlbum = true;

            //the last Id in the album array.
            int lastAlbumId = 0;

            //the last Id in the album array.
            int lastSongId = 0;

            //looping through each of the albums in the array.
            foreach(Album album in albumsDB)
            {
                lastAlbumId = album.Id;
            }


            //if the album Id is 0 that means nothing was selected from the drop down menu.
            if (viewModel.Song.AlbumId == 0 || viewModel.Song.AlbumId == null)
            {
                if (song.Album.Name == null)
                {
                    Console.WriteLine("Please enter a value");
                }
                else
                {
                    Artist albumArtist;
                    int albumId = lastAlbumId;
                    Album theAlbum;

                    //if the last album Id is 0 then theres no need to add 1.
                    if (lastAlbumId != 0)
                        albumId = albumId + 1;

                    //if the user has chosen an artist from the list.
                    if (song.ArtistId != 0)
                    {
                        albumArtist = artistsDB[song.ArtistId - 1];
                        //creating a new album with the information we have.
                        theAlbum = new Album
                        {
                            Name = song.Album.Name,
                            Id = albumId,
                            ArtistId = song.ArtistId
                        };

                        //setting the album of the song to be the one we have just created.
                        song.Album = theAlbum;

                        string sql = "INSERT INTO Albums VALUES(@Id, @Name, @ArtistId)";

                        _context.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("Id", albumId),
                            new SqlParameter("Name", song.Album.Name),
                            new SqlParameter("ArtistId", song.ArtistId)
                         );

                        //_context.Album.Add(theAlbum);
                        //saving the album to the database.
                        /*
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            return Content(e.ToString());
                        }
                        */

                        //setting the genreId of the song to be that of what was just created.
                        int insertedId = albumId;
                        song.AlbumId = insertedId;
                    }

                    Console.WriteLine("The new album name was: " + song.Album.Name);
                }
            }
            //else something was selected from the drop down meny so we set the album name to be the Id of what was selected.
            else
            {
                //setting the album name to be the value of the existing album.
                song.Album.Name = albumsDB[song.AlbumId.Value - 1].Name;
                Console.WriteLine("The album " + albumsDB[song.AlbumId.Value - 1] + " already exists.");
            }



            if (!ModelState.IsValid)
            {


                var thisViewModel = new SongFormViewModel
                {
                    Song = song,
                    Albums = albums,
                    Genres = genres,
                    Artists = artists
                };

                return View("SongForm", thisViewModel);
            }

            
            //if the song is a new song.
            if (song.Id == 0 || song.Id == null)
            {

                foreach (Song theSong in songs)
                {
                    lastSongId = theSong.Id.Value;
                }

                //_context.Song.Add(song);
                song.Id = lastSongId + 1;
            }
            //else we are editing a song that already exists.
            else
            {

            }

            try
            {
                string sql = "INSERT INTO Songs VALUES (@Id, @Name, @GenreId, @Released, @Description, @ArtistId, @AlbumId)";
                _context.Database.ExecuteSqlCommand(sql,
                    new SqlParameter("Id", song.Id),
                    new SqlParameter("Name", song.Name),
                    new SqlParameter("GenreId", song.GenreId),
                    new SqlParameter("Released", song.Released),
                    new SqlParameter("Description", song.Description),
                    new SqlParameter("ArtistId", song.ArtistId),
                    new SqlParameter("AlbumId", song.AlbumId)
                    );
                _context.SaveChanges();
            } catch (Exception e)
            {
                return Content(e.ToString());
            }

            //also adding the list of songs here so we can send the user back to the songs index page.
            var songViewModel = new SongViewModel
            {
                Songs = songs,
                Genres = genres,
                Albums = albums,
                Artists = artists
            };

            return View("Index", songViewModel);
        }

        //disposing the _context.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}