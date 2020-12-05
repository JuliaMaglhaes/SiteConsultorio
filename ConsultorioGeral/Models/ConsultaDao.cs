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
                Data = DateTime.Now,
                Sintomas = "Descrição dos sintomas",
                Cpf = "123456789101"
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

