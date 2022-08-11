using AutoMapper;
using GeekShoping.ProductAPI.Dominio.Modelos;
using GeekShoping.ProductAPI.Models.InputModel;

namespace GeekShoping.ProductAPI.Configuracoes
{
    public class ConfiguracaoMapeamento
    {
        public static MapperConfiguration RegistrarMapeamento()
        {
            var mapConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<ProdutoInputModel, Produto>();
                conf.CreateMap<Produto, ProdutoInputModel>();
            });

            return mapConfig;
        }
    }
}
