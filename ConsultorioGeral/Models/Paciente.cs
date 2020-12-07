using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class Paciente
    { 
        [Key]
        public long? PacienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Idade { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }

        public string Telefone { get; set; }
        public List<Consulta> Consultas { get; set; }

        
        public Paciente()
        {

        }
    }
}
