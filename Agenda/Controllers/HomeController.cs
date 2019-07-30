using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using Agenda.Connection;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            using (var contexto = new CrudDAOentity())
            {
                ViewBag.dados = contexto.contatos().ToList();         
            }
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult cadastrarAction(string nome, string telefone, string email, string cidade)
        {
            using (var contexto = new CrudDAOentity())
            {
                contatos dados = new contatos();

                dados.CON_NOME = nome;
                dados.CON_TELEFONE = telefone;
                dados.CON_EMAIL = email;
                dados.CON_CIDADE = cidade;
                
                contexto.Adicionar(dados);
                return RedirectToAction("Index", new { });
            }
        }

        public ActionResult Atualizar(string codigoContato)
        {
            try
            {
                var cod = Convert.ToInt32(codigoContato);
                using (var cont = new CrudDAOentity())
                {
                    var dados = cont.contatos().Where(c => c.CON_ID == cod);
                    ViewBag.nome = dados.Select(c => c.CON_NOME).First();
                    ViewBag.telefone = dados.Select(c => c.CON_TELEFONE).First();
                    ViewBag.email = dados.Select(c => c.CON_EMAIL).First();
                    ViewBag.cidade = dados.Select(c => c.CON_CIDADE).First();
                    ViewBag.codigo = dados.Select(c => c.CON_ID).First();
                }
            }
            catch (Exception)
            {
                //return null;
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult atualizarCadastro(string codigoContato, string nome, string telefone, string email, string cidade)
        {
            var cod = Convert.ToInt32(codigoContato);
            using (var contexto = new CrudDAOentity())
            {
                var dados = contexto.contatos().Where(c => c.CON_ID == cod).ToList();
                var item = dados.First();
                item.CON_NOME = nome;
                item.CON_TELEFONE = telefone;
                item.CON_EMAIL = email;
                item.CON_CIDADE = cidade;

                contexto.Atualizar(item);
            }
            return RedirectToAction("Index", new { });
        }
        

        public ActionResult excluirCadastro(string codigoContato)
        {
            var cod = Convert.ToInt32(codigoContato);
            using (var contexto = new CrudDAOentity())
            {
                var dados = contexto.contatos().Where(c => c.CON_ID == cod).ToList();
                var item = dados.First();
                contexto.Remover(item);
            }

            return RedirectToAction("Index", new { });
        }
        /*
       [HttpPost]
       public ActionResult atualizarCadastro(int codigoContato, string nome, string telefone, string email, string cidade)
       {
           return RedirectToAction("atualizarCadastroAction",new {codigoContato, nome, telefone, email, cidade });
       }

         */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
