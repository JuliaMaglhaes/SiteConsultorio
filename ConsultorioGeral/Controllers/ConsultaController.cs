using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using ConsultorioGeral.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using ConsultorioGeral.Models;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace ConsultorioGeral.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly PacienteContext _context;

        public ConsultaController(PacienteContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultas.OrderBy(a => a.Sintomas).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ConsultaId, Horário, Dia, Sintomas, Cpf, MedicoEsp")] Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(consulta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados");
            }
            return View(consulta);
        }

        public async Task<IActionResult> Details(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consultas.SingleOrDefaultAsync(a => a.ConsultaId == Id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }

        public async Task<IActionResult> Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consultas.SingleOrDefaultAsync(a => a.ConsultaId == Id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? Id, [Bind("ConsultaId, Horário, Dia, Sintomas, Cpf, MedicoEsp")] Consulta consulta)
        {
            if (Id != consulta.ConsultaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.ConsultaId))
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
            return View(consulta);
        }
        public bool ConsultaExists(long? Id)
        {
            return _context.Consultas.Any(a => a.ConsultaId == Id);
        }

        public async Task<IActionResult> Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consultas.SingleOrDefaultAsync(a => a.ConsultaId == Id);
            if (consulta == null)
            {
                NotFound();
            }
            return View(consulta);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long? Id)
        {
            var consulta = await _context.Consultas.SingleOrDefaultAsync(a => a.ConsultaId == Id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
