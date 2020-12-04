using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD_Lab5.Models;

namespace NETD_Lab5.Controllers
{
    public class CompletedPromptsController : Controller
    {
        private readonly PromptContext _context;

        public CompletedPromptsController(PromptContext context)
        {
            _context = context;
        }

        // GET: CompletedPrompts
        public async Task<IActionResult> Index()
        {
       
            return View(await _context.CompletedPrompts.ToListAsync());
        }

        // GET: CompletedPrompts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedPrompts = await _context.CompletedPrompts
                .FirstOrDefaultAsync(m => m.completed_id == id);
            if (completedPrompts == null)
            {
                return NotFound();
            }

            return View(completedPrompts);
        }

        // GET: CompletedPrompts/Create
        public IActionResult Create()
        {
            //Getting Data from DB
            List<Prompts> promptList = new List<Prompts>();
            ViewData["p_id"] = new SelectList(_context.Prompts, "p_id", "prompt");

            return View();
        }

        // POST: CompletedPrompts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("completed_id,p_id,book_name,author_name,rating")] CompletedPrompts completedPrompts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(completedPrompts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(completedPrompts);
        }

        // GET: CompletedPrompts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedPrompts = await _context.CompletedPrompts.FindAsync(id);
            if (completedPrompts == null)
            {
                return NotFound();
            }
            return View(completedPrompts);
        }

        // POST: CompletedPrompts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("completed_id,p_id,book_name,author_name,rating")] CompletedPrompts completedPrompts)
        {
            if (id != completedPrompts.completed_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(completedPrompts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompletedPromptsExists(completedPrompts.completed_id))
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
            return View(completedPrompts);
        }

        // GET: CompletedPrompts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completedPrompts = await _context.CompletedPrompts
                .FirstOrDefaultAsync(m => m.completed_id == id);
            if (completedPrompts == null)
            {
                return NotFound();
            }

            return View(completedPrompts);
        }

        // POST: CompletedPrompts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var completedPrompts = await _context.CompletedPrompts.FindAsync(id);
            _context.CompletedPrompts.Remove(completedPrompts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompletedPromptsExists(int id)
        {
            return _context.CompletedPrompts.Any(e => e.completed_id == id);
        }
    }
}
