using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchokoCinema.Controllers.Database;
using SchokoCinema.Database;
using SchokoCinema.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchokoCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Movie> movies = GetAllMovies();

            // de lijst met namen in de html stoppen
            return View(movies );
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

        [Route("contact")]

        public IActionResult Contact()
        {
            return View();
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        [Route("succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("filmdetails")]
        public IActionResult filmdetails()
        {
            return View();
        }

        [Route("movie/{id}")]
        public IActionResult Filmdetails(int id)
        {
            var movie = GetMovie(id);

            return View(movie);
        }

        public List<Movie> GetAllMovies()
        {
            var rows = DatabaseConnector.GetRows("select * from movie");

            List<Movie> movies = new List<Movie>();

            foreach (var row in rows)
            {
                Movie m = new Movie();
                m.Titel = row["titel"].ToString();
                m.Poster = row["poster"].ToString();
                m.beschrijving = row["beschrijving"].ToString();
                m.id = Convert.ToInt32(row["id"]);

                movies.Add(m);
            }

            return movies;
        }
        public Movie GetMovie(int id)
        {
            var rows = DatabaseConnector.GetRows($"select * from movie where id = {id}");

            List<Movie> movies = new List<Movie>();

            foreach (var row in rows)
            {
                Movie m = new Movie();
                m.Titel = row["titel"].ToString();
                m.Poster = row["poster"].ToString();
                m.beschrijving = row["beschrijving"].ToString();
                m.id = Convert.ToInt32(row["id"]);

                movies.Add(m);
            }

            return movies[0];
        }

    }

}




