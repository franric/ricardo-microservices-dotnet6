using AutoMapper;
using GeekShoping.ProductAPI.Configuracoes;
using GeekShoping.ProdutoAPI.Infra.Context;
using GeekShopping.ProductAPI.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GeekShoping.ProductAPI
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MysqlConnectionString"];

            services.AddDbContext<MysqlContext>(opt =>
                opt.UseMySql(connection, new MySqlServerVersion(new Version(5, 7, 36))));
            
            IMapper mapper = ConfiguracaoMapeamento.RegistrarMapeamento().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShoping - Produto API", Version = "1" });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
