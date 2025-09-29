using Microsoft.AspNetCore.Mvc;
using CrudSimples.Models;
using CrudSimples.Services;

namespace CrudSimples.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var produtos = _produtoService.GetAll();
            return View(produtos);
        }

        public IActionResult Details(int id)
        {
            var produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoService.Add(produto);
                TempData["Message"] = "Produto criado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public IActionResult Edit(int id)
        {
            var produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _produtoService.Update(produto);
                TempData["Message"] = "Produto atualizado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public IActionResult Delete(int id)
        {
            var produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _produtoService.Delete(id);
            TempData["Message"] = "Produto excluído com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}