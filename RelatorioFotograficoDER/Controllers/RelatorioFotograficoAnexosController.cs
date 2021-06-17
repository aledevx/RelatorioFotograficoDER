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
    public class RelatorioFotograficoAnexosController : Controller
    {
        private readonly DataContext _context;

        public RelatorioFotograficoAnexosController(DataContext context)
        {
            _context = context;
        }

        // GET: RelatorioFotograficoAnexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelatorioFotograficoAnexos.ToListAsync());
        }

        // GET: RelatorioFotograficoAnexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotograficoAnexo = await _context.RelatorioFotograficoAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioFotograficoAnexo == null)
            {
                return NotFound();
            }

            return View(relatorioFotograficoAnexo);
        }

        // GET: RelatorioFotograficoAnexos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioFotograficoAnexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Caminho,RelatorioAtesteId")] RelatorioFotograficoAnexo relatorioFotograficoAnexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioFotograficoAnexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioFotograficoAnexo);
        }

        // GET: RelatorioFotograficoAnexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotograficoAnexo = await _context.RelatorioFotograficoAnexos.FindAsync(id);
            if (relatorioFotograficoAnexo == null)
            {
                return NotFound();
            }
            return View(relatorioFotograficoAnexo);
        }

        // POST: RelatorioFotograficoAnexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Caminho,RelatorioAtesteId")] RelatorioFotograficoAnexo relatorioFotograficoAnexo)
        {
            if (id != relatorioFotograficoAnexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioFotograficoAnexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioFotograficoAnexoExists(relatorioFotograficoAnexo.Id))
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
            return View(relatorioFotograficoAnexo);
        }

        // GET: RelatorioFotograficoAnexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotograficoAnexo = await _context.RelatorioFotograficoAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioFotograficoAnexo == null)
            {
                return NotFound();
            }

            return View(relatorioFotograficoAnexo);
        }

        // POST: RelatorioFotograficoAnexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioFotograficoAnexo = await _context.RelatorioFotograficoAnexos.FindAsync(id);
            _context.RelatorioFotograficoAnexos.Remove(relatorioFotograficoAnexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioFotograficoAnexoExists(int id)
        {
            return _context.RelatorioFotograficoAnexos.Any(e => e.Id == id);
        }
    }
}
