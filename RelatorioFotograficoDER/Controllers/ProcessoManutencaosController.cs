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
    public class ProcessoManutencaosController : Controller
    {
        private readonly DataContext _context;

        public ProcessoManutencaosController(DataContext context)
        {
            _context = context;
        }

        // GET: ProcessoManutencaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessoManutencaos.ToListAsync());
        }

        // GET: ProcessoManutencaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoManutencao = await _context.ProcessoManutencaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoManutencao == null)
            {
                return NotFound();
            }

            return View(processoManutencao);
        }

        // GET: ProcessoManutencaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessoManutencaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RelatoriofotograficoId,CoordenacaoId,RelatorioAtesteId")] ProcessoManutencao processoManutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processoManutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processoManutencao);
        }

        // GET: ProcessoManutencaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoManutencao = await _context.ProcessoManutencaos.FindAsync(id);
            if (processoManutencao == null)
            {
                return NotFound();
            }
            return View(processoManutencao);
        }

        // POST: ProcessoManutencaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RelatoriofotograficoId,CoordenacaoId,RelatorioAtesteId")] ProcessoManutencao processoManutencao)
        {
            if (id != processoManutencao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processoManutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoManutencaoExists(processoManutencao.Id))
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
            return View(processoManutencao);
        }

        // GET: ProcessoManutencaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoManutencao = await _context.ProcessoManutencaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoManutencao == null)
            {
                return NotFound();
            }

            return View(processoManutencao);
        }

        // POST: ProcessoManutencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processoManutencao = await _context.ProcessoManutencaos.FindAsync(id);
            _context.ProcessoManutencaos.Remove(processoManutencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoManutencaoExists(int id)
        {
            return _context.ProcessoManutencaos.Any(e => e.Id == id);
        }
    }
}
