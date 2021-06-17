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
    public class PdfAnexosController : Controller
    {
        private readonly DataContext _context;

        public PdfAnexosController(DataContext context)
        {
            _context = context;
        }

        // GET: PdfAnexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PdfAnexos.ToListAsync());
        }

        // GET: PdfAnexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfAnexo = await _context.PdfAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdfAnexo == null)
            {
                return NotFound();
            }

            return View(pdfAnexo);
        }

        // GET: PdfAnexos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PdfAnexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Caminho")] PdfAnexo pdfAnexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdfAnexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pdfAnexo);
        }

        // GET: PdfAnexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfAnexo = await _context.PdfAnexos.FindAsync(id);
            if (pdfAnexo == null)
            {
                return NotFound();
            }
            return View(pdfAnexo);
        }

        // POST: PdfAnexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,Caminho")] PdfAnexo pdfAnexo)
        {
            if (id != pdfAnexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdfAnexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdfAnexoExists(pdfAnexo.Id))
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
            return View(pdfAnexo);
        }

        // GET: PdfAnexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfAnexo = await _context.PdfAnexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdfAnexo == null)
            {
                return NotFound();
            }

            return View(pdfAnexo);
        }

        // POST: PdfAnexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdfAnexo = await _context.PdfAnexos.FindAsync(id);
            _context.PdfAnexos.Remove(pdfAnexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdfAnexoExists(int id)
        {
            return _context.PdfAnexos.Any(e => e.Id == id);
        }
    }
}
