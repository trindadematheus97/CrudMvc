using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "api_consulta_cep",
              "paginas/consulta-cep/{cep}",
              new { Controller = "Cep", action = "Index", id = 0 }
              );

            routes.MapRoute(
              "paginas_preview",
              "paginas/{id}/preview",
              new { Controller = "Paginas", action = "Preview", id = 0 }
              );

            routes.MapRoute(
              "paginas_alterar",
              "paginas/{id}/alterar",
              new { Controller = "Paginas", action = "Alterar", id = 0 }
              );

            routes.MapRoute(
              "paginas_excluir",
              "paginas/{id}/excluir",
              new { Controller = "Paginas", action = "Excluir", id = 0 }
              );

            routes.MapRoute(
              "paginas_editar",
              "paginas/{id}/editar",
              new { Controller = "Paginas", action = "Editar", id= 0 }
              );

            routes.MapRoute(
               "paginas_criar",
               "paginas/criar",
               new { Controller = "Paginas", action = "Criar" }
               );

            routes.MapRoute(
               "paginas_novo",
               "paginas/novo",
               new { Controller = "Paginas", action = "Novo" }
               );

            routes.MapRoute(
                "paginas",
                "paginas",
                new {Controller = "Paginas", action = "Index"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
