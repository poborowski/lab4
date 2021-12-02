using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BooksModelsController : Controller
    {
        private readonly WebApplication3Context _context;

        public BooksModelsController(WebApplication3Context context)
        {
            _context = context;
        }

        // GET: BooksModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.BooksModel.ToListAsync());
        }

        // GET: BooksModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksModel = await _context.BooksModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksModel == null)
            {
                return NotFound();
            }

            return View(booksModel);
        }

        // GET: BooksModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Category,Price")] BooksModel booksModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booksModel);
        }

        // GET: BooksModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksModel = await _context.BooksModel.FindAsync(id);
            if (booksModel == null)
            {
                return NotFound();
            }
            return View(booksModel);
        }

        // POST: BooksModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Category,Price")] BooksModel booksModel)
        {
            if (id != booksModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksModelExists(booksModel.Id))
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
            return View(booksModel);
        }

        // GET: BooksModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksModel = await _context.BooksModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksModel == null)
            {
                return NotFound();
            }

            return View(booksModel);
        }

        // POST: BooksModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booksModel = await _context.BooksModel.FindAsync(id);
            _context.BooksModel.Remove(booksModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksModelExists(int id)
        {
            return _context.BooksModel.Any(e => e.Id == id);
        }
    }
}
