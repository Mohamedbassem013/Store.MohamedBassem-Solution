
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.MohamedBassem.Domain;
using Store.MohamedBassem.Domain.Mapping.Products;
using Store.MohamedBassem.Domain.Services.Contract;
using Store.MohamedBassem.Repository;
using Store.MohamedBassem.Repository.Data.Contexts;
using Store.MohamedBassem.Service.Services.Products;

namespace Store.MohamedBassem.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IProductServices, ProductService>();//depancy injections
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//depancy injections
         
            builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile()));//depancy injections

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            
            var Service = scope.ServiceProvider;
          
            var context = Service.GetRequiredService<StoreDbContext>();
           
            var LoggerFactory = Service.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {

              var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "There are Probems during apply Migrations !!");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
