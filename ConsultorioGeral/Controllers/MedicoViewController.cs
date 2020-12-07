using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsultorioGeral.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using ConsultorioGeral.Models;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace ConsultorioGeral.Controllers
{
    public class MedicoViewController : Controller
    {

        private readonly PacienteContext _context;

        public MedicoViewController(PacienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult ResponderDiagnostico(long consultaId, string diagnostico)
        {
            var consulta = _context.Consultas.Find(consultaId);
            if(consulta == null)
                return Json(new { status = false});

            consulta.Diagnostico = diagnostico;
            _context.Consultas.Update(consulta);
            _context.SaveChanges();

            return Json(new { status = true });
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicos.OrderBy(a => a.Nome).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("MedicoId, Nome, Crm, Especialidade ")] Medico medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(medico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados");
            }
            return View(medico);
        }



        public async Task<IActionResult> Details(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(x => x.Consultas)
                .SingleOrDefaultAsync(a => a.MedicoId == Id);

            ViewBag.Consultas = _context.Consultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Where(a => a.MedicoId == Id).ToList();

            if (medico == null)
            {
                return NotFound();

            }
            return View(medico);
            /*
            var medico = await _context.Medicos.SingleOrDefaultAsync(a => a.MedicoId == Id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
            */
        }

        public async Task<IActionResult> Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var medico = await _context.Medicos.SingleOrDefaultAsync(a => a.MedicoId == Id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? Id, [Bind("MedicoId, Nome, Crm, Especialidade ")] Medico medico)
        {
            if (Id != medico.MedicoId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.MedicoId))
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
            return View(medico);
        }
        public bool MedicoExists(long? Id)
        {
            return _context.Medicos.Any(a => a.MedicoId == Id);
        }

        public async Task<IActionResult> Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var medico = await _context.Medicos.SingleOrDefaultAsync(a => a.MedicoId == Id);
            if (medico == null)
            {
                NotFound();
            }
            return View(medico);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long? Id)
        {
            var medico = await _context.Medicos.SingleOrDefaultAsync(a => a.MedicoId == Id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
