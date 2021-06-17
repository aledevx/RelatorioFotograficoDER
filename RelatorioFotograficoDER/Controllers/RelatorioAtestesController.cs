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
    public class RelatorioAtestesController : Controller
    {
        private readonly DataContext _context;

        public RelatorioAtestesController(DataContext context)
        {
            _context = context;
        }

        // GET: RelatorioAtestes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelatorioAtestes.ToListAsync());
        }

        // GET: RelatorioAtestes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAteste = await _context.RelatorioAtestes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioAteste == null)
            {
                return NotFound();
            }

            return View(relatorioAteste);
        }

        // GET: RelatorioAtestes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioAtestes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,DataAprovacao,Descricao,DataInicio,DataFim,DataAtualizacao")] RelatorioAteste relatorioAteste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioAteste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioAteste);
        }

        // GET: RelatorioAtestes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAteste = await _context.RelatorioAtestes.FindAsync(id);
            if (relatorioAteste == null)
            {
                return NotFound();
            }
            return View(relatorioAteste);
        }

        // POST: RelatorioAtestes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,DataAprovacao,Descricao,DataInicio,DataFim,DataAtualizacao")] RelatorioAteste relatorioAteste)
        {
            if (id != relatorioAteste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioAteste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioAtesteExists(relatorioAteste.Id))
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
            return View(relatorioAteste);
        }

        // GET: RelatorioAtestes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioAteste = await _context.RelatorioAtestes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioAteste == null)
            {
                return NotFound();
            }

            return View(relatorioAteste);
        }

        // POST: RelatorioAtestes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioAteste = await _context.RelatorioAtestes.FindAsync(id);
            _context.RelatorioAtestes.Remove(relatorioAteste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioAtesteExists(int id)
        {
            return _context.RelatorioAtestes.Any(e => e.Id == id);
        }
    }
}
