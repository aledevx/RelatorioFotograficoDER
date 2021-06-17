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
    public class RelatorioFotograficosController : Controller
    {
        private readonly DataContext _context;

        public RelatorioFotograficosController(DataContext context)
        {
            _context = context;
        }

        // GET: RelatorioFotograficos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelatorioFotograficos.ToListAsync());
        }

        // GET: RelatorioFotograficos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotografico = await _context.RelatorioFotograficos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioFotografico == null)
            {
                return NotFound();
            }

            return View(relatorioFotografico);
        }

        // GET: RelatorioFotograficos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioFotograficos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Setor,Veiculo,NumOrcamento,Cartao,Placa,Patrimonio,Kmh,Ano,Telefone,Responsavel,Matricula,Email,Descricao,DataInicio,DataEnvio,DataAtualizacao")] RelatorioFotografico relatorioFotografico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioFotografico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioFotografico);
        }

        // GET: RelatorioFotograficos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotografico = await _context.RelatorioFotograficos.FindAsync(id);
            if (relatorioFotografico == null)
            {
                return NotFound();
            }
            return View(relatorioFotografico);
        }

        // POST: RelatorioFotograficos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Setor,Veiculo,NumOrcamento,Cartao,Placa,Patrimonio,Kmh,Ano,Telefone,Responsavel,Matricula,Email,Descricao,DataInicio,DataEnvio,DataAtualizacao")] RelatorioFotografico relatorioFotografico)
        {
            if (id != relatorioFotografico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioFotografico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioFotograficoExists(relatorioFotografico.Id))
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
            return View(relatorioFotografico);
        }

        // GET: RelatorioFotograficos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioFotografico = await _context.RelatorioFotograficos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioFotografico == null)
            {
                return NotFound();
            }

            return View(relatorioFotografico);
        }

        // POST: RelatorioFotograficos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioFotografico = await _context.RelatorioFotograficos.FindAsync(id);
            _context.RelatorioFotograficos.Remove(relatorioFotografico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioFotograficoExists(int id)
        {
            return _context.RelatorioFotograficos.Any(e => e.Id == id);
        }
    }
}
