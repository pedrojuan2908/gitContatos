using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class contatos
    {
        [Key]
        public int CON_ID { get; internal set; }
        public string CON_NOME { get; internal set; }
        public string CON_TELEFONE { get; internal set; }
        public string CON_EMAIL { get; internal set; }
        public string CON_CIDADE { get; internal set; }
    }
}
