using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class ConsultaDao
    {
        public ConsultaDao()
        {
        }
        private static IList<Consulta> consultas = new List<Consulta>()
        {
            new Consulta()
            {
                Horario = Convert.ToDateTime("31/11/2020"),
                Dia= Convert.ToDateTime("12:00"),
                Sintomas = "Descrição dos sintomas",
                Cpf = "123456789101",
                MedicoEsp = "Clinico Geral",
            }
        };

        public async Task<Consulta> GravarConsulta(Consulta consulta)
        {
            consultas.Add(consulta);
            return consulta;
        }
        public IList<Consulta> ObterTodos()
        {
            return consultas;
        }
    }
}

