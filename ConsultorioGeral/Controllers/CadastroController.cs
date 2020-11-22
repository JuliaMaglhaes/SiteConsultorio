using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioGeral.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Paciente()
        {
            return View();
        }
        public IActionResult Consulta()
        {
            return View();
        }
    }
}
