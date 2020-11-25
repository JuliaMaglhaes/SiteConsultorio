using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class PacienteDao
    {
        public PacienteDao()
        {
        }
        private static IList<Paciente> pacientes = new List<Paciente>()
        {
            new Paciente()
            {
                Nome = "Júlia",
                Cpf = "02120400000",
                Idade = "19",
                Email = "juliatorres203@gmail.com",
                Sexo = "Feminino",
                Endereco = "Avenida dos Acadêmicos",
                Cep = "27175-000",
                Telefone = "(24)992940332"
            }
        };

        public async Task<Paciente> GravarPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
            return paciente;
        }
        public IList<Paciente> ObterTodos()
        {
            return pacientes;
        }
    }
}

