
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

  
    public class ActorController: Controller
    {
        private readonly IActorServices _services;

        public ActorController(IActorServices service)
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
        public async Task<IActionResult> Create([Bind("ActorName,ActorUrl,Bio")]Actor actor)
        {
            if(ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //get details by id
        public async Task<IActionResult> Detail(int id)
        {
            var actorDetail = await _services.GetByIdAsync(id);
            if (actorDetail == null)
                return View("Empty");
            return View(actorDetail);
        }

        //get actors-Edit
        public async Task<IActionResult> Edit(int id)
        {

            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails ==null) return View("empty");
            return View(actorDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ActorName,ActorUrl,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
        //Delete
        public async Task<IActionResult> Delete(int id)
        {

            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails ==null) return View("NoFound");
            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConformation(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("not found");
          
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }

    
}
