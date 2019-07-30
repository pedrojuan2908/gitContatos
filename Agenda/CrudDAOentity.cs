using Agenda.Connection;
using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda
{
    internal class CrudDAOentity : CrudDAO, IDisposable
    {
        private Conexao contexto;

        public CrudDAOentity()
        {
            this.contexto = new Conexao();
        }

        public void Adicionar(contatos c)
        {
            contexto.contatos.Add(c);
            contexto.SaveChanges();
        }

        public void Atualizar(contatos c)
        {
            contexto.contatos.Update(c);
            contexto.SaveChanges();
        }

        public IList<contatos> contatos()
        {
            return contexto.contatos.ToList();
        }

        public void Remover(contatos c)
        {
            contexto.contatos.Remove(c);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
