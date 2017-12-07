﻿using System;
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

            //the last Id in the album array.
            int lastAlbumId = 0;

            //looping through each of the albums in the array.
            foreach(Album album in albumsDB)
            {
                lastAlbumId = lastAlbumId + 1;
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

            //if the song is a new song.
            if(song.Id == 0)
            {
                //if the album Id is 0 that means nothing was selected from the drop down menu.
                if (viewModel.Song.AlbumId == 0)
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
                            albumArtist = artistsDB[song.ArtistId];
                            //creating a new album with the information we have.
                            theAlbum = new Album
                            {
                                Name = song.Album.Name,
                                Id = albumId,
                                Artist = albumArtist
                            };

                            //setting the album of the song to be the one we have just created.
                            song.Album = theAlbum;

                            _context.Album.Add(theAlbum);
                            //saving the album to the database.
                            try
                            {
                                _context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return Content(e.ToString());
                            }

                            //setting the genreId of the song to be that of what was just created.
                            int insertedId = theAlbum.Id;
                            song.GenreId = insertedId;
                        }

                        Console.WriteLine("The new album name was: " + song.Album.Name);
                    }
                }
                //else something was selected from the drop down meny so we set the album name to be the Id of what was selected.
                else
                {
                    //setting the album name to be the value of the existing album.
                    song.Album.Name = albumsDB[song.AlbumId].Name;
                    Console.WriteLine("The album " + albumsDB[song.AlbumId] + " already exists.");
                }

                _context.Song.Add(song);
            }
            //else we are editing a song that already exists.
            else
            {

            }

            try
            {
                _context.SaveChanges();
            } catch (Exception e)
            {
                return Content(e.ToString());
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