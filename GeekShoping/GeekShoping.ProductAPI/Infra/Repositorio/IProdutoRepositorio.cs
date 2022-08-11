using GeekShoping.ProductAPI.Models.InputModel;

namespace GeekShopping.ProductAPI.Infra.Repositorio
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<ProdutoInputModel>> FindAll();
        Task<ProdutoInputModel> FindById(long id);
        Task<ProdutoInputModel> Create(ProdutoInputModel model);
        Task<ProdutoInputModel> Update(ProdutoInputModel model);
        Task<bool> Delete(long id);
    }
}
