using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment3.Data;
using moment3.Models;

namespace moment3.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MvcAlbumContext _context;

        public AlbumController(MvcAlbumContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index(string searchString)
        {

            var albums = _context.Album.Include(s => s.Artist);
            
            return View(await albums.ToListAsync());
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var album = await _context.Album
                        .Include(s => s.Artist)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.AlbumId == id);

            
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        public async Task<IActionResult> Create()
        {                                        
            var artists = await _context.Artist.ToListAsync();
            ViewBag.Artist = artists;

            return View();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,ArtistId,Title,ReleaseDate,AmountOfSongs,PlayTime")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            var artists = await _context.Artist.ToListAsync();
            ViewBag.Artist = artists;
            return View(album);
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,ArtistId,Title,ReleaseDate,AmountOfSongs,PlayTime")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Album.FindAsync(id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumId == id);
        }
    }
}
