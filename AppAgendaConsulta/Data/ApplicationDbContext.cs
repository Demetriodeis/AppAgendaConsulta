using System;
using System.Collections.Generic;
using System.Text;
using AppAgendaConsulta.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAgendaConsulta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<ConsultaMedica> ConsultaMedicas { get; set; }
    }
}
