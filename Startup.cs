using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Entities;
using Persistence.Repositories;
using Services.Services;

namespace DesafioProtechAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioProtechAPI", Version = "v1" });
            });

            // Injetando o Context
            services.AddDbContext<DBContext>(x => x.UseMySQL(Configuration.GetConnectionString("mysql")));
            // Injetando as services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IFormacaoService, FormacaoService>();
            services.AddScoped<IExperienciaService, ExperienciaService>();
            services.AddScoped<IExperienciaEmpresaService, ExperienciaEmpresaService>();
            // Injetando os repos
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFormacaoRepository, FormacaoRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped<IExperienciaEmpresaRepository, ExperienciaEmpresaRepository>();
            // Injetando o automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioModel, Usuario>().ReverseMap();
                cfg.CreateMap<FormacaoModel, Formacao>().ReverseMap();
                cfg.CreateMap<ExperienciaModel, Experiencia>().ReverseMap();
                cfg.CreateMap<ExperienciaEmpresaModel, Experienciaempresa>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioProtechAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
