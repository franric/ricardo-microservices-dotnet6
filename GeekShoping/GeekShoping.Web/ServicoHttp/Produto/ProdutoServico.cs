using GeekShoping.Web.Models.Produto;
using GeekShoping.Web.Utils;

namespace GeekShoping.Web.ServicoHttp.Produto
{
    public class ProdutoService : IProdutoServico
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/produto";

        public ProdutoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProdutoModel> CreateProduct(ProdutoModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if(response.IsSuccessStatusCode) return await response.GetAsync<ProdutoModel>();
            throw new Exception("Error ao chamar a api");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return await response.GetAsync<bool>();
        }

        public async Task<IEnumerable<ProdutoModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.GetAsync<List<ProdutoModel>>();
        }

        public async Task<ProdutoModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.GetAsync<ProdutoModel>();
        }

        public async  Task<ProdutoModel> UpdateProduct(ProdutoModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.GetAsync<ProdutoModel>();
            throw new Exception("Error ao chamar a api");
        }
    }
}
