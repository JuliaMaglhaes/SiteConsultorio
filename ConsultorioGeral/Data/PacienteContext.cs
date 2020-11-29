using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsultorioGeral.Models;

namespace ConsultorioGeral.Data
{
    public class PacienteContext:DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}

