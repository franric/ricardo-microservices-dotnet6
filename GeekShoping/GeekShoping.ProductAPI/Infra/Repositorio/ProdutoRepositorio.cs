using AutoMapper;
using GeekShoping.ProductAPI.Dominio.Modelos;
using GeekShoping.ProductAPI.Models.InputModel;
using GeekShoping.ProdutoAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Infra.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MysqlContext _context;
        private IMapper _mapper;
        
        public ProdutoRepositorio(MysqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoInputModel>> FindAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoInputModel>>(produtos);
        }

        public async Task<ProdutoInputModel> FindById(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return _mapper.Map<ProdutoInputModel>(produto);
        }

        public async Task<ProdutoInputModel> Create(ProdutoInputModel model)
        {
            var produto = _mapper.Map<Produto>(model);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProdutoInputModel>(produto);
        }

        public async Task<ProdutoInputModel> Update(ProdutoInputModel model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProdutoInputModel>(produto);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null) return false;
                
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
