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
   
    public class ProducerController : Controller
    {
        private readonly IProducerServices _services;

        public ProducerController(IProducerServices service)
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
        public async Task<IActionResult> Create([Bind("ProducerName,ProducerUrl,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                return View(producer);
            }
            await _services.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //get details by id
        public async Task<IActionResult> Detail(int id)
        {
            var ProducerDetail = await _services.GetByIdAsync(id);
            if (ProducerDetail == null)
                return View("Empty");
            return View(ProducerDetail);
        }

        //get actors-Edit
        public async Task<IActionResult> Edit(int id)
        {

            var ProducerDetail = await _services.GetByIdAsync(id);
            if (ProducerDetail ==null) return View("empty");
            return View(ProducerDetail);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProducerName,ProducerUrl,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                return View(producer);
            }
            await _services.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        //Delete
        public async Task<IActionResult> Delete(int id)
        {

            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails ==null) return View("NoFound");
            return View(producerDetails);

        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConformation(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("not found");

            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
