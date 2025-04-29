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
    public class CastAndCrewsController : Controller
    {
        private readonly AppDbContext _context;

        public CastAndCrewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CastAndCrews
        public async Task<IActionResult> Index()
        {
            return View(await _context.CastAndCrews.ToListAsync());
        }

        // GET: CastAndCrews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castAndCrew = await _context.CastAndCrews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (castAndCrew == null)
            {
                return NotFound();
            }

            return View(castAndCrew);
        }

        // GET: CastAndCrews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CastAndCrews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,StageName,BirthDate,Description,ImageUrl,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] CastAndCrew castAndCrew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(castAndCrew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(castAndCrew);
        }

        // GET: CastAndCrews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castAndCrew = await _context.CastAndCrews.FindAsync(id);
            if (castAndCrew == null)
            {
                return NotFound();
            }
            return View(castAndCrew);
        }

        // POST: CastAndCrews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,StageName,BirthDate,Description,ImageUrl,Id,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Comments")] CastAndCrew castAndCrew)
        {
            if (id != castAndCrew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(castAndCrew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastAndCrewExists(castAndCrew.Id))
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
            return View(castAndCrew);
        }

        // GET: CastAndCrews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castAndCrew = await _context.CastAndCrews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (castAndCrew == null)
            {
                return NotFound();
            }

            return View(castAndCrew);
        }

        // POST: CastAndCrews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var castAndCrew = await _context.CastAndCrews.FindAsync(id);
            if (castAndCrew != null)
            {
                _context.CastAndCrews.Remove(castAndCrew);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastAndCrewExists(int id)
        {
            return _context.CastAndCrews.Any(e => e.Id == id);
        }
    }
}
