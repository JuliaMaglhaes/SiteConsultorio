using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioGeral.Models
{
    public class Consulta
    {
        [Key]
        public long? ConsultaId { get; set; }

        public DateTime Data { get; set ;}
        public string Sintomas { get; set; }
        public string Cpf { get; set; }
        public string Diagnostico { get; set; }

       // public string? Descricao { get; set; }

        [ForeignKey("Paciente")]
        public long? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("Medico")]
        public long? MedicoId { get; set; }
        public virtual Medico Medico { get; set; }

        public Consulta() { }
    }
}
