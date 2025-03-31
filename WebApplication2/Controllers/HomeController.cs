using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DBMovie _context;

        public HomeController(ILogger<HomeController> logger,DBMovie context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Movie movie = new Movie();
            movie.Id = 44;
            //movie.Title = "abc";
            return View(movie);
        }

        public IActionResult Movie() {
            //Movie movie = new Movie();
            var allMovies = _context.Movies.ToList();
            return View(allMovies);
        }

        public IActionResult ViewMovies() {
            return View();
        }

        public IActionResult MovieForm(Movie model) {
            _context.Movies.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Movie");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
