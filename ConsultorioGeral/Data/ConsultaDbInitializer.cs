using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioGeral.Data
{
    public class ConsultaDbInitializer
    {
        public static void Initialize(PacienteContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
