using Cuide.api.Data;
using Cuide.api.Repositories;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services;
using Cuide.api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPrestadorService, PrestadorService>();
            builder.Services.AddScoped<IServicoService, ServicoService>();
            builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();

            // Add repositories

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPrestadorRepository, PrestadorRepository>();
            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
            builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Um erro aconteceu durante a migração.");
            }

            app.Run();
        }
    }
}