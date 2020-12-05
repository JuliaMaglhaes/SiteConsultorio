using ConsultorioGeral.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class Medico
    {
        [Key]
        public long? MedicoId { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public Especialidade Especialidade { get; set; }
        public List<Consulta> Consultas { get; set; }
        public Medico() { }
    }
}
