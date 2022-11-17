using eMovies.Data;
using eMovies.Data.Services;
using eMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Controllers
{
    public class MediasController : Controller
    { 
        private readonly IMediasService _service;

        public MediasController(IMediasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMedias = await _service.GetAllAsync();
            return View(allMedias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description")] Media media)
        {
            if (!ModelState.IsValid)
            {
                return View(media);
            }
            await _service.AddAsync(media);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var mediaDetails = await _service.GetByIdAsync(id);

            if (mediaDetails == null) return View("Empty");
            return View(mediaDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var mediaDetails = await _service.GetByIdAsync(id);
            if (mediaDetails == null) return View("Empty");
            return View(mediaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Media media)
        {
            if (!ModelState.IsValid)
            {
                return View(media);
            }
            await _service.UpdateAsync(id, media);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var mediaDetails = await _service.GetByIdAsync(id);
            if (mediaDetails == null) return View("Empty");
            return View(mediaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaDetails = await _service.GetByIdAsync(id);
            if (mediaDetails == null) return View("Empty");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
