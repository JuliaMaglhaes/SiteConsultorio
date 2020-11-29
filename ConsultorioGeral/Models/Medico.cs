using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class Medico
    {
        public long? MedicoId { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public Medico() { }
    }
}
