using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsultorioGeral.Models;

namespace ConsultorioGeral.Controllers
{
    public class CadastroController : Controller
    {
        private readonly PacienteDao pacienteDao = new PacienteDao();

        public IActionResult Paciente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Paciente([Bind("Nome, Cpf, Idade, Email, Sexo, Endereco, Cep, Telefone")] Paciente paciente)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    await pacienteDao.GravarPaciente(paciente);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados. " + e.Message);
            }
            return View(paciente);
        }
        public async Task<IActionResult> Index()
        {
            return View(pacienteDao.ObterTodos());
        }

        // public IActionResult IndexCad()
        //{
        //    return View(pacienteDao.ObterTodos());
        //}


    }
}
