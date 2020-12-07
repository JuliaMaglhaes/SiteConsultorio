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

namespace academico.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteContext _context;

        public PacienteController(PacienteContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacientes.OrderBy(a => a.Nome).ToListAsync());
        }
        


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("PacienteId, Nome, Cpf, Idade, Email, Sexo, Endereco, Cep, Telefone")] Paciente paciente)
        {
            try
            {
                if (paciente.Cpf.Length != 11)
                {
                    ModelState.AddModelError("Cpf", "CPF inválido");
                }
                if (ModelState.IsValid)
                {
                    _context.Add(paciente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados");
            }
            return View(paciente);
        }

        public async Task<IActionResult> Details(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes
                .Include(x => x.Consultas)
                .SingleOrDefaultAsync(a => a.PacienteId == Id);

            ViewBag.Consultas = _context.Consultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Where(a => a.PacienteId == Id).ToList();

            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.SingleOrDefaultAsync(a => a.PacienteId == Id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? Id, [Bind("PacienteId, Nome, Cpf, Idade, Email, Sexo, Endereco, Cep, Telefone")] Paciente paciente)
        {
            if (Id != paciente.PacienteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PacienteId))
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
            return View(paciente);
        }
        public bool PacienteExists(long? Id)
        {
            return _context.Pacientes.Any(a => a.PacienteId == Id);
        }

        public async Task<IActionResult> Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.SingleOrDefaultAsync(a => a.PacienteId == Id);
            if (paciente == null)
            {
                NotFound();
            }
            return View(paciente);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long? Id)
        {
            var paciente = await _context.Pacientes.SingleOrDefaultAsync(a => a.PacienteId == Id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}



