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
    public class RatingValuesController : Controller
    {
        private readonly AppDbContext _context;

        public RatingValuesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RatingValues
        public async Task<IActionResult> Index()
        {
            return View(await _context.RatingValues.ToListAsync());
        }

        // GET: RatingValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingValue = await _context.RatingValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ratingValue == null)
            {
                return NotFound();
            }

            return View(ratingValue);
        }

        // GET: RatingValues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RatingValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] RatingValue ratingValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ratingValue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ratingValue);
        }

        // GET: RatingValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingValue = await _context.RatingValues.FindAsync(id);
            if (ratingValue == null)
            {
                return NotFound();
            }
            return View(ratingValue);
        }

        // POST: RatingValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Value,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] RatingValue ratingValue)
        {
            if (id != ratingValue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ratingValue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingValueExists(ratingValue.Id))
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
            return View(ratingValue);
        }

        // GET: RatingValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingValue = await _context.RatingValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ratingValue == null)
            {
                return NotFound();
            }

            return View(ratingValue);
        }

        // POST: RatingValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ratingValue = await _context.RatingValues.FindAsync(id);
            if (ratingValue != null)
            {
                _context.RatingValues.Remove(ratingValue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingValueExists(int id)
        {
            return _context.RatingValues.Any(e => e.Id == id);
        }
    }
}
