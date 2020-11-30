using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsultorioGeral.Models;

namespace ConsultorioGeral.Controllers
{
    public class CadController : Controller
    {
        private readonly ConsultaDao consultaDao = new ConsultaDao();

        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Consulta([Bind(" Horario, Dia, Sintomas, Cpf, MedicoEsp")] Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await consultaDao.GravarConsulta(consulta);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados. " + e.Message);
            }
            return View(consulta);
        }

        public async Task<IActionResult> Index()
        {
            return View(consultaDao.ObterTodos());
        }

        public IActionResult IndexCad()
        {
            return View(consultaDao.ObterTodos());
        }
    }
}
