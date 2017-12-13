using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rythmm.Models;
using Rythmm.ViewModels;
using System.Data.SqlClient;
namespace Rythmm.Controllers
{
    public class AlbumController : Controller
    {

        private ApplicationDbContext _context;

        //constructor
        public AlbumController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Album
        [Route("Album")]
        public ActionResult Index()
        {
            var albums = _context.Album.ToList();
            var artists = _context.Artist.ToList();

            //creating a view model with all the artists and albums
            AlbumIndexViewModel viewModel = new AlbumIndexViewModel()
            {
                Artists = artists,
                Albums = albums
            };

            return View("Index", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}