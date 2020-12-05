using ConsultorioGeral.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioGeral.Models
{
    public class Medico
    {
        [Key]
        public long? MedicoId { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public Especialidade Especialidade { get; set; }
        public Medico() { }
    }
}
