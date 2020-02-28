using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment3.Data;
using moment3.Models;

namespace moment3.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MvcAlbumContext _context;

        public ArtistController(MvcAlbumContext context)
        {
            _context = context;
        }

        // GET: Artist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artist.ToListAsync());
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var albums = await _context.Album
                .Where(a => a.ArtistId == id)
                .Select(a => a.Title)
                .ToListAsync();

            var artist = await _context.Artist
                .Include(a => a.Albums)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            ViewBag.Album = albums;
            return View(artist);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,FullName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,FullName")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .FirstOrDefaultAsync(a => a.ArtistId == id);

            if (album != null)
            {
                ViewData["album"] = "This artist has saved albums, delete them first if you want to delete this artist";
                return View(artist);
            }

            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.ArtistId == id);
        }
    }
}
