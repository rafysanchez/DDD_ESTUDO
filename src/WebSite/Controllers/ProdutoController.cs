using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface;
using WebSite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSite.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IAppProduto _IAppProduto;

        public ProdutoController(IAppProduto IAppProduto)
        {
            _IAppProduto = IAppProduto;
        }

        /// <summary>
        /// Listagem 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewData["Title"] = "Lista de Produto";

            var Lista = _IAppProduto.List();
            var Retorno = new List<ProdutoModel>();
            foreach (var item in Lista)
            {
                Retorno.Add(new Models.ProdutoModel { Id = item.Id, NomeProduto = item.NomeProduto });
            }
            return View(Retorno);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Novo Produto";
            return View(new ProdutoModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ProdutoModel produto)
        {
            ViewData["Title"] = "Novo Produto";
            _IAppProduto.Add(new Entities.Produto { NomeProduto = produto.NomeProduto });

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Produto";
            var produto = _IAppProduto.GetForId(id);

            return View(new ProdutoModel { Id = produto.Id, NomeProduto = produto.NomeProduto });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ProdutoModel produto)
        {
            ViewData["Title"] = "Editar Produto";
            var prod = _IAppProduto.GetForId(produto.Id);
            prod.NomeProduto = produto.NomeProduto;
            _IAppProduto.Update(prod);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Exclusão de Produto";
            var produto = _IAppProduto.GetForId(id);

            return View(new ProdutoModel { Id = produto.Id, NomeProduto = produto.NomeProduto });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(ProdutoModel produto)
        {
            ViewData["Title"] = "Exclusão de Produto";
            _IAppProduto.Delete(produto.Id);
            return RedirectToAction("Index");
        }

    }
}
