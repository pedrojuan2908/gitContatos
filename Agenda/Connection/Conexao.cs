using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Connection
{
    internal class Conexao : DbContext
    {
        public DbSet<contatos> contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AgendaDB;Trusted_Connection=true;");

        }
    }
}