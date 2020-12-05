using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Enums
{
    public enum Especialidade
    {
        Cardiologista = 1,
        Pediatra = 2,
        Otorrinolaringologista = 3,
        [Display(Name = "Clínico Geral")]
        ClinicoGeral = 4,
    }
}
