using GeekShoping.ProductAPI.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GeekShoping.ProductAPI.Infra.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(){}
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options){}
        public DbSet<Produto> Produtos { get; set; }
    }
}
