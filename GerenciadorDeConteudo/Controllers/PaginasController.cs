using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            var model = new Pagina().Lista();

            return View(model);
        }
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.Save();
            Response.Redirect("/paginas");
        }

        public ActionResult Editar(int id)
        {
            var pagina =  Pagina.BuscaPorId(id);

            return View(pagina);
        }

        public ActionResult Preview(int id)
        {
            var pagina = Pagina.BuscaPorId(id);

            return View(pagina);
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.Editar();

                TempData["Sucesso"] = "Página alterada com sucesso";
            }
            catch(Exception err)
            {
                TempData["Erro"] = "Página não pode alterada ("+ err.Message + ")";
            }
            

            Response.Redirect("/paginas");
        }

        public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }

    }
}