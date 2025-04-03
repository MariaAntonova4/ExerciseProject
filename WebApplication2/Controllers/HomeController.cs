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

        public IActionResult ViewMovies(int? id) {
            if (id!=null)
            {
                var moviesInDB = _context.Movies.SingleOrDefault(x => x.Id == id);
                return View(moviesInDB);
            }
            return View();
        }

        public IActionResult DeleteMovies(int? id) {
            var moviesInDB = _context.Movies.SingleOrDefault(x=>x.Id==id);
            _context.Movies.Remove(moviesInDB);
            _context.SaveChanges();
            return RedirectToAction("Movie");
        }

        public IActionResult MovieForm(Movie model) {
            if (model.Id == 0)
            {
                _context.Movies.Add(model);
            }
            else {
                _context.Movies.Update(model);
            }

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
