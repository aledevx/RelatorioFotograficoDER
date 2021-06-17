using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelatorioFotograficoDER.Data;
using RelatorioFotograficoDER.Models;

namespace RelatorioFotograficoDER.Controllers
{
    public class RelatorioAtesteAnexosController : Controller
    {
        private readonly DataContext _context;

        public RelatorioAtesteAnexosController(DataContext context)
        {
            _context = context;
        }

        // GET: RelatorioAtesteAnexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelatorioAtesteAnexos.ToListAsync());
        }

        // GET: RelatorioAtesteAnexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAtesteAnexo = await _context.RelatorioAtesteAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioAtesteAnexo == null)
            {
                return NotFound();
            }

            return View(relatorioAtesteAnexo);
        }

        // GET: RelatorioAtesteAnexos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioAtesteAnexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Caminho,RelatorioAtesteId")] RelatorioAtesteAnexo relatorioAtesteAnexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioAtesteAnexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioAtesteAnexo);
        }

        // GET: RelatorioAtesteAnexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAtesteAnexo = await _context.RelatorioAtesteAnexos.FindAsync(id);
            if (relatorioAtesteAnexo == null)
            {
                return NotFound();
            }
            return View(relatorioAtesteAnexo);
        }

        // POST: RelatorioAtesteAnexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Caminho,RelatorioAtesteId")] RelatorioAtesteAnexo relatorioAtesteAnexo)
        {
            if (id != relatorioAtesteAnexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioAtesteAnexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioAtesteAnexoExists(relatorioAtesteAnexo.Id))
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
            return View(relatorioAtesteAnexo);
        }

        // GET: RelatorioAtesteAnexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAtesteAnexo = await _context.RelatorioAtesteAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioAtesteAnexo == null)
            {
                return NotFound();
            }

            return View(relatorioAtesteAnexo);
        }

        // POST: RelatorioAtesteAnexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioAtesteAnexo = await _context.RelatorioAtesteAnexos.FindAsync(id);
            _context.RelatorioAtesteAnexos.Remove(relatorioAtesteAnexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioAtesteAnexoExists(int id)
        {
            return _context.RelatorioAtesteAnexos.Any(e => e.Id == id);
        }
    }
}
