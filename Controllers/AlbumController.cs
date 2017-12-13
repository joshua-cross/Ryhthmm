using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rythmm.Models;
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
            var Albums = _context.Album.ToList();

            return View("Index", Albums);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}