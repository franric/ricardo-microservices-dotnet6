using GeekShoping.Web.Models.Produto;

namespace GeekShoping.Web.ServicoHttp.Produto
{
    public interface IProdutoServico
    {
        Task<IEnumerable<ProdutoModel>> FindAllProducts();
        Task<ProdutoModel> FindProductById(long id);
        Task<ProdutoModel> CreateProduct(ProdutoModel model);
        Task<ProdutoModel> UpdateProduct(ProdutoModel model);
        Task<bool> DeleteProductById(long id);
    }
}
