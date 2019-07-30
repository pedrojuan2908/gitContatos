using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda
{
    interface CrudDAO
    { 
        void Adicionar(contatos c);
        void Atualizar(contatos c);
        void Remover(contatos c);
        IList<contatos> contatos();
    }
}
