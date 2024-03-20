using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01
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

            builder.Services.AddDbContext<BMWDBContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContextRemote")));
          
            builder.Services.AddScoped<IDataRepository<Accessoire>, AccessoireManager>();
            builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
            builder.Services.AddScoped<IDataRepository<Caracteristique>, CaracteristiqueManager>();
            builder.Services.AddScoped<IDataRepository<CategorieAccessoire>, CategorieAccessoireManager>();
            builder.Services.AddScoped<IDataRepository<CategorieCaracteristique>, CategorieCaracteristiqueManager>();
            builder.Services.AddScoped<IDataRepository<CategorieEquipement>, CategorieEquipementManager>();
            builder.Services.AddScoped<IDataRepository<Client>, ClientManager>();
            builder.Services.AddScoped<IDataRepository<Collection>, CollectionManager>();
            builder.Services.AddScoped<IDataRepository<Coloris>, ColorisManager>();
            builder.Services.AddScoped<IDataRepository<Commande>, CommandeManager>();

            builder.Services.AddScoped<IDataRepository<Style>, StyleManager>();
            builder.Services.AddScoped<IDataRepository<Taille>, TailleManager>();
            builder.Services.AddScoped<IDataRepository<Telephone>, TelephoneManager>();
            builder.Services.AddScoped<IDataRepository<Transaction>, TransactionManager>();
            builder.Services.AddScoped<IDataRepository<Users>, UserManager>();

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

            app.Run();
        }
    }
}