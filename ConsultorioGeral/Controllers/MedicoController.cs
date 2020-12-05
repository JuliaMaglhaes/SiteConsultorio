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
    public class MedicoController : Controller
    {
        private readonly MedicoDao medicoDao = new MedicoDao();

        public IActionResult Medico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Medico([Bind("Nome, Crm, Especialidade")] Medico medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await medicoDao.GravarMedico(medico);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados." + e.Message);
            }
            return View(medico);
        }
        public async Task<IActionResult> Index()
        {
            return View(medicoDao.ObterTodos());
        }
    }
}
