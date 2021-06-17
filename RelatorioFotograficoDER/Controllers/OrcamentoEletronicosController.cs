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
    public class OrcamentoEletronicosController : Controller
    {
        private readonly DataContext _context;

        public OrcamentoEletronicosController(DataContext context)
        {
            _context = context;
        }

        // GET: OrcamentoEletronicos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.OrcamentoEletronicos.Include(o => o.PdfAnexo);
            return View(await dataContext.ToListAsync());
        }

        // GET: OrcamentoEletronicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoEletronico = await _context.OrcamentoEletronicos
                .Include(o => o.PdfAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamentoEletronico == null)
            {
                return NotFound();
            }

            return View(orcamentoEletronico);
        }

        // GET: OrcamentoEletronicos/Create
        public IActionResult Create()
        {
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id");
            return View();
        }

        // POST: OrcamentoEletronicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,Codigo,PdfAnexoId")] OrcamentoEletronico orcamentoEletronico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamentoEletronico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", orcamentoEletronico.PdfAnexoId);
            return View(orcamentoEletronico);
        }

        // GET: OrcamentoEletronicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoEletronico = await _context.OrcamentoEletronicos.FindAsync(id);
            if (orcamentoEletronico == null)
            {
                return NotFound();
            }
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", orcamentoEletronico.PdfAnexoId);
            return View(orcamentoEletronico);
        }

        // POST: OrcamentoEletronicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Codigo,PdfAnexoId")] OrcamentoEletronico orcamentoEletronico)
        {
            if (id != orcamentoEletronico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamentoEletronico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoEletronicoExists(orcamentoEletronico.Id))
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
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", orcamentoEletronico.PdfAnexoId);
            return View(orcamentoEletronico);
        }

        // GET: OrcamentoEletronicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoEletronico = await _context.OrcamentoEletronicos
                .Include(o => o.PdfAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamentoEletronico == null)
            {
                return NotFound();
            }

            return View(orcamentoEletronico);
        }

        // POST: OrcamentoEletronicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orcamentoEletronico = await _context.OrcamentoEletronicos.FindAsync(id);
            _context.OrcamentoEletronicos.Remove(orcamentoEletronico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoEletronicoExists(int id)
        {
            return _context.OrcamentoEletronicos.Any(e => e.Id == id);
        }
    }
}
