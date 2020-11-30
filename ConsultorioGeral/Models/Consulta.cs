using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class Consulta
    {
        public long? ConsultaId { get; set; }

        public string Horario { get; set ;}
        public string Dia { get; set; }
        public string Sintomas { get; set; }
        public string Cpf { get; set; }
        public string MedicoEsp { get; set; }
        public long? PacienteId { get; set; }
        public  Paciente Paciente { get; set; }

        public Consulta() { }
    }
}
