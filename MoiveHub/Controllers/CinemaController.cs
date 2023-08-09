using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoiveHub.Data;
using MoiveHub.Data.Services;
using MoiveHub.Data.Statics;
using MoiveHub.Models;
using System.Data;

namespace MoiveHub.Controllers
{
    
    public class CinemaController : Controller
    {
        private readonly ICinemaServices _services;

        public CinemaController(ICinemaServices service)
        {
            _services = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _services.GetAllAsync();
            return View(data);
        }
        //get actors-create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CinemaName,CinemaUrl,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                return View(cinema);
            }
            await _services.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //get details by id
        public async Task<IActionResult> Detail(int id)
        {
            var cinemaDetail = await _services.GetByIdAsync(id);
            if (cinemaDetail == null)
                return View("Empty");
            return View(cinemaDetail);
        }

        //get actors-Edit
        public async Task<IActionResult> Edit(int id)
        {

            var cinemaDetails = await _services.GetByIdAsync(id);
            if (cinemaDetails ==null) return View("empty");
            return View(cinemaDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CinemaName,CinemaUrl,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                return View(cinema);
            }
            await _services.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        //Delete
        public async Task<IActionResult> Delete(int id)
        {

            var cinemaDetails = await _services.GetByIdAsync(id);
            if (cinemaDetails ==null) return View("NoFound");
            return View(cinemaDetails);

        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConformation(int id)
        {
            var cinemaDetails = await _services.GetByIdAsync(id);
            if (cinemaDetails == null) return View("not found");

            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
