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
    public class CoordenacaosController : Controller
    {
        private readonly DataContext _context;

        public CoordenacaosController(DataContext context)
        {
            _context = context;
        }

        // GET: Coordenacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coordenacaos.ToListAsync());
        }

        // GET: Coordenacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenacao = await _context.Coordenacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordenacao == null)
            {
                return NotFound();
            }

            return View(coordenacao);
        }

        // GET: Coordenacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coordenacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrcamentoeletronicoId,RelacaoOrcamentoId,DataInicio,DataEnvio,DataAtualizacao")] Coordenacao coordenacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coordenacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coordenacao);
        }

        // GET: Coordenacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenacao = await _context.Coordenacaos.FindAsync(id);
            if (coordenacao == null)
            {
                return NotFound();
            }
            return View(coordenacao);
        }

        // POST: Coordenacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrcamentoeletronicoId,RelacaoOrcamentoId,DataInicio,DataEnvio,DataAtualizacao")] Coordenacao coordenacao)
        {
            if (id != coordenacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coordenacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordenacaoExists(coordenacao.Id))
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
            return View(coordenacao);
        }

        // GET: Coordenacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordenacao = await _context.Coordenacaos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordenacao == null)
            {
                return NotFound();
            }

            return View(coordenacao);
        }

        // POST: Coordenacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordenacao = await _context.Coordenacaos.FindAsync(id);
            _context.Coordenacaos.Remove(coordenacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordenacaoExists(int id)
        {
            return _context.Coordenacaos.Any(e => e.Id == id);
        }
    }
}
