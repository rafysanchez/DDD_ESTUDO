using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Interface;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class ProdutoController : Controller
    {


        private readonly IAppProduto _IAppProduto;

        public ProdutoController(IAppProduto IAppProduto)
        {
            _IAppProduto = IAppProduto;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            var Retorno = new List<ProdutoModel>();

            var Lista = _IAppProduto.List();
            foreach (var item in Lista)
            {
                Retorno.Add(new ProdutoModel { Id = item.Id, NomeProduto = item.NomeProduto });
            }

            return View(Retorno);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Novo Produto";
            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produto)
        {
            ViewData["Title"] = "Novo Produto";
            _IAppProduto.Add(new Entities.Produto { NomeProduto = produto.NomeProduto });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edição do Produto";
            var Editar = _IAppProduto.GetForId(id);
            var Retorno = new ProdutoModel { NomeProduto = Editar.NomeProduto, Id = Editar.Id };
            return View(Retorno);
        }

        [HttpPost]
        public IActionResult Edit(ProdutoModel Produto)
        {
            ViewData["Title"] = "Edição do Produto";
            var Editar = _IAppProduto.GetForId(Produto.Id);
            Editar.NomeProduto = Produto.NomeProduto;
            _IAppProduto.Update(Editar);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Deletar Produto";
            var Editar = _IAppProduto.GetForId(id);
            var Retorno = new ProdutoModel { NomeProduto = Editar.NomeProduto, Id = Editar.Id };
            return View(Retorno);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
           
            _IAppProduto.Delete(id);

            return RedirectToAction("Index");
        }


    }
}
