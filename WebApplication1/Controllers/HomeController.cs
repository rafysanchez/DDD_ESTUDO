using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface;
using Entities;

namespace WebApplication1.Controllers
{
    

    public class HomeController : Controller
    {

        private readonly IAppProduto _IAppProduto;

        public HomeController(IAppProduto IAppProduto)
        {
            _IAppProduto = IAppProduto;
        }

        public IActionResult Index()
        {

            _IAppProduto.Add(new Produto { NomeProduto = "casa val e" });

            return View();
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
