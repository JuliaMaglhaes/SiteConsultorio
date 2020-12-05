using ConsultorioGeral.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Models
{
    public class MedicoDao
    {
        public MedicoDao()
        {
        }
        private static readonly IList<Medico> medicos = new List<Medico>()
        {
            new Medico()
            {
                Nome = "Doutor",
                Crm = "0123456",
                Especialidade = Especialidade.ClinicoGeral
            }
        };

        public async Task<Medico> GravarMedico(Medico medico)
        {
            medicos.Add(medico);
            return medico;
        }
        public IList<Medico> ObterTodos()
        {
            return medicos;
        }
    }
}

