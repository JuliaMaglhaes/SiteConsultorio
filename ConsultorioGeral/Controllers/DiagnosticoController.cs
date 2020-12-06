using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioGeral.Data;
using ConsultorioGeral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioGeral.Controllers
{
    public class DiagnosticoController : Controller
    {
        private readonly PacienteContext _context;

        public DiagnosticoController(PacienteContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diagnosticos.OrderBy(a => a.Descricao).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("DiagnosticoId, Descricao ")] Diagnostico diagnostico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(diagnostico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados");
            }
            return View(diagnostico);
        }

        public async Task<IActionResult> Details(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos.SingleOrDefaultAsync(a => a.DiagnosticoId == Id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            return View(diagnostico);
            
        }

        public async Task<IActionResult> Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var medico = await _context.Diagnosticos.SingleOrDefaultAsync(a => a.DiagnosticoId == Id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? Id, [Bind("DiagnosticoId, Descricao ")] Diagnostico diagnostico)
        {
            if (Id != diagnostico.DiagnosticoId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnostico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticoExists(diagnostico.DiagnosticoId))
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
            return View(diagnostico);
        }
        public bool DiagnosticoExists(long? Id)
        {
            return _context.Diagnosticos.Any(a => a.DiagnosticoId == Id);
        }

        public async Task<IActionResult> Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var diagnostico = await _context.Diagnosticos.SingleOrDefaultAsync(a => a.DiagnosticoId == Id);
            if (diagnostico == null)
            {
                NotFound();
            }
            return View(diagnostico);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long? Id)
        {
            var diagnostico = await _context.Diagnosticos.SingleOrDefaultAsync(a => a.DiagnosticoId == Id);
            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}

