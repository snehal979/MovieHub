using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoiveHub.Data;
using MoiveHub.Data.Services;
using MoiveHub.Data.Statics;
using MoiveHub.Data.ViewModel;
using MoiveHub.Models;

namespace MoiveHub.Controllers
{
   
    public class MovieController : Controller
    {
        private readonly IMovieServices _services;

        public MovieController(IMovieServices service)
        {
            _services = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _services.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }
        //get actors-create
        public async Task<IActionResult> Create()
        {
            var movieDropDown = await  _services.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDown.Cinemas, "Id", "CinemaName");
            ViewBag.Producer = new SelectList(movieDropDown.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDown.Actors, "Id", "ActorName");
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieDropDown = await _services.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDown.Cinemas, "Id", "CinemaName");
                ViewBag.Producers = new SelectList(movieDropDown.Producers, "Id", "ProducerName");
                ViewBag.Actors = new SelectList(movieDropDown.Actors, "Id", "ActorName");
                return View(movie);
            }
            await _services.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //get details by id
      
        public async Task<IActionResult> Detail(int id)
        {
            var movieDetail = await _services.GetMovieByIdAsync(id);
            if (movieDetail == null) return View("Empty");
            return View(movieDetail);
           
        }
        //get actors-Edit
        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _services.GetMovieByIdAsync(id);
            if (movieDetails ==null) return View("empty");
            var response = new NewMovieModel()
            {
                Id = movieDetails.Id,
                MovieName = movieDetails.MovieName,
                Description = movieDetails.Description,
                Prize = movieDetails.Prize,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieUrl = movieDetails.MovieUrl,
                MovieCatogory = movieDetails.MovieCatogory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorId = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
           
            var movieDropDown = await _services.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDown.Cinemas, "Id", "CinemaName");
            ViewBag.Producer = new SelectList(movieDropDown.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDown.Actors, "Id", "ActorName");
            
            return View(response);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieModel movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropDown = await _services.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDown.Cinemas, "Id", "CinemaName");
                ViewBag.Producer = new SelectList(movieDropDown.Producers, "Id", "ProducerName");
                ViewBag.Actors = new SelectList(movieDropDown.Actors, "Id", "ActorName");
                return View(movie);
            }
            await _services.UpdateNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
       
        //Delete
        //public async Task<IActionResult> Delete(int id)
        //{

        //    var movieDetails = await _services.GetByIdAsync(id);
        //    if (movieDetails ==null) return View("NoFound");
        //    return View(movieDetails);

        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConformation(int id)
        //{
        //    var movieDetails = await _services.GetMovieByIdAsync(id);
        //    if (movieDetails == null) return View("not found");

        //    await _services.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
        //Filter movie
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovie = await _services.GetAllAsync(n=>n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.MovieName.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovie.Where(n => string.Equals(n.MovieName, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovie);
        }

    }
}
