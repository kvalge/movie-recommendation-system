using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain.Entities;

namespace WebApp.Controllers
{
    public class MovieRecommendationsController : Controller
    {
        private readonly AppDbContext _context;

        public MovieRecommendationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovieRecommendations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MovieRecommendations.Include(m => m.Movie).Include(m => m.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MovieRecommendations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRecommendation = await _context.MovieRecommendations
                .Include(m => m.Movie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRecommendation == null)
            {
                return NotFound();
            }

            return View(movieRecommendation);
        }

        // GET: MovieRecommendations/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "CreatedBy");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MovieRecommendations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Score,Reason,IsViewed,UserId,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] MovieRecommendation movieRecommendation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieRecommendation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "CreatedBy", movieRecommendation.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movieRecommendation.UserId);
            return View(movieRecommendation);
        }

        // GET: MovieRecommendations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRecommendation = await _context.MovieRecommendations.FindAsync(id);
            if (movieRecommendation == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "CreatedBy", movieRecommendation.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movieRecommendation.UserId);
            return View(movieRecommendation);
        }

        // POST: MovieRecommendations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Score,Reason,IsViewed,UserId,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] MovieRecommendation movieRecommendation)
        {
            if (id != movieRecommendation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieRecommendation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRecommendationExists(movieRecommendation.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "CreatedBy", movieRecommendation.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movieRecommendation.UserId);
            return View(movieRecommendation);
        }

        // GET: MovieRecommendations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRecommendation = await _context.MovieRecommendations
                .Include(m => m.Movie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRecommendation == null)
            {
                return NotFound();
            }

            return View(movieRecommendation);
        }

        // POST: MovieRecommendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieRecommendation = await _context.MovieRecommendations.FindAsync(id);
            if (movieRecommendation != null)
            {
                _context.MovieRecommendations.Remove(movieRecommendation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRecommendationExists(int id)
        {
            return _context.MovieRecommendations.Any(e => e.Id == id);
        }
    }
}
