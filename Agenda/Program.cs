using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Connection;
using Agenda.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Agenda
{
    internal class Program : CrudDAOentity
    {
        public static void Main(string[] args)
        {
            //Gravar();
            Ler();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static void Atualizar()
        { 
            using (var repositorio = new CrudDAOentity())
            {
                contatos primeiro = repositorio.contatos().First();

                repositorio.Atualizar(primeiro);
            }

        }

        public static void Remover()
        {
            using (var repositorio = new CrudDAOentity())
            {
                IList<contatos> c = repositorio.contatos();
                foreach (var item in c)
                {
                    repositorio.Remover(item);
                }
            }
        }

        public static void Ler()
        {
            using (var repositorio = new CrudDAOentity())
            {
                IList<contatos> c = repositorio.contatos();
            }
        }

        public static void Gravar()
        {
            contatos c = new contatos();

            using (var contexto = new CrudDAOentity())
            {
                contexto.Adicionar(c);
            }
        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
