using GeekShoping.Web.Models.Produto;
using GeekShoping.Web.ServicoHttp.Produto;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoping.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public async Task<IActionResult> ProdutoIndex()
        {
            var produto = await _produtoServico.FindAllProducts();
            return View(produto);
        }

        public async Task<IActionResult> ProdutoCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProdutoCreate(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                var novoProduto = await _produtoServico.CreateProduct(produto);
                if (novoProduto != null) return RedirectToAction(nameof(ProdutoIndex));
            }
            return View(produto);
        }

        public async Task<IActionResult> ProdutoUpdate(int id)
        {
            var produto = await _produtoServico.FindProductById(id);
            if (produto != null) return View(produto);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProdutoUpdate(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                var novoProduto = await _produtoServico.UpdateProduct(produto);
                if (novoProduto != null) return RedirectToAction(nameof(ProdutoIndex));
            }

            return View(produto);
        }

        public async Task<IActionResult> ProdutoDelete(int id)
        {
            var produto = await _produtoServico.FindProductById(id);
            if (produto != null) return View(produto);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProdutoDelete(ProdutoModel produto)
        {
            var deletadoProduto = await _produtoServico.DeleteProductById(produto.Id);
            if (deletadoProduto) return RedirectToAction(nameof(ProdutoIndex));

            return View(produto);
        }
    }
}
