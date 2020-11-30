using System;
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
        public string MedicoEsp { get; set; }

        [ForeignKey("Paciente")]
        public long? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public Consulta() { }
    }
}
