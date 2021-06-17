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
    public class RelacaoOrcamentosController : Controller
    {
        private readonly DataContext _context;

        public RelacaoOrcamentosController(DataContext context)
        {
            _context = context;
        }

        // GET: RelacaoOrcamentos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.RelacaoOrcamentos.Include(r => r.PdfAnexo);
            return View(await dataContext.ToListAsync());
        }

        // GET: RelacaoOrcamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacaoOrcamento = await _context.RelacaoOrcamentos
                .Include(r => r.PdfAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relacaoOrcamento == null)
            {
                return NotFound();
            }

            return View(relacaoOrcamento);
        }

        // GET: RelacaoOrcamentos/Create
        public IActionResult Create()
        {
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id");
            return View();
        }

        // POST: RelacaoOrcamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,Codigo,PdfAnexoId")] RelacaoOrcamento relacaoOrcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relacaoOrcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", relacaoOrcamento.PdfAnexoId);
            return View(relacaoOrcamento);
        }

        // GET: RelacaoOrcamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacaoOrcamento = await _context.RelacaoOrcamentos.FindAsync(id);
            if (relacaoOrcamento == null)
            {
                return NotFound();
            }
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", relacaoOrcamento.PdfAnexoId);
            return View(relacaoOrcamento);
        }

        // POST: RelacaoOrcamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Codigo,PdfAnexoId")] RelacaoOrcamento relacaoOrcamento)
        {
            if (id != relacaoOrcamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relacaoOrcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacaoOrcamentoExists(relacaoOrcamento.Id))
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
            ViewData["PdfAnexoId"] = new SelectList(_context.PdfAnexos, "Id", "Id", relacaoOrcamento.PdfAnexoId);
            return View(relacaoOrcamento);
        }

        // GET: RelacaoOrcamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacaoOrcamento = await _context.RelacaoOrcamentos
                .Include(r => r.PdfAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relacaoOrcamento == null)
            {
                return NotFound();
            }

            return View(relacaoOrcamento);
        }

        // POST: RelacaoOrcamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relacaoOrcamento = await _context.RelacaoOrcamentos.FindAsync(id);
            _context.RelacaoOrcamentos.Remove(relacaoOrcamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacaoOrcamentoExists(int id)
        {
            return _context.RelacaoOrcamentos.Any(e => e.Id == id);
        }
    }
}
