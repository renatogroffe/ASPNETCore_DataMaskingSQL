using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace SiteDataMasking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(
            [FromServices]IConfiguration config)
        {
            List<Cliente> clientes;

            using (SqlConnection conexao =
                new SqlConnection(
                    config.GetConnectionString("ExemploDataMask")))
            {
                clientes = conexao.Query<Cliente>(
                    "SELECT * " +
                    "FROM dbo.Clientes").AsList();
            }

            return View(clientes);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}