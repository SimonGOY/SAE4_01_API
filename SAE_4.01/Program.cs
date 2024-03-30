using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            builder.Services.AddScoped<IDataRepository<Concessionnaire>, ConcessionnaireManager>();
            builder.Services.AddScoped<IDataRepository<ContactInfo>, ContactInfoManager>();
            builder.Services.AddScoped<IDataRepository<ContenuCommande>, ContenuCommandeManager>();
            builder.Services.AddScoped<IDataRepository<Couleur>, CouleurManager>();
            builder.Services.AddScoped<IDataRepository<DemandeEssai>, DemandeEssaiManager>();
            builder.Services.AddScoped<IDataRepository<Equipement>, EquipementManager>();
            builder.Services.AddScoped<IDataRepository<EstInclus>, EstInclusManager>();
            builder.Services.AddScoped<IDataRepository<EstLie>, EstLieManager>();
            builder.Services.AddScoped<IDataRepository<GammeMoto>, GammeMotoManager>();
            builder.Services.AddScoped<IDataRepository<Garage>, GarageManager>();
            builder.Services.AddScoped<IDataRepository<InfoCB>, InfoCBManager>();
            builder.Services.AddScoped<IDataRepository<Media>, MediaManager>();
            builder.Services.AddScoped<IDataRepository<ModeleMoto>, ModeleMotoManager>();
            builder.Services.AddScoped<IDataRepository<MotoConfigurable>, MotoConfigurableManager>();
            builder.Services.AddScoped<IDataRepository<MotoDisponible>, MotoDisponibleManager>();
            builder.Services.AddScoped<IDataRepository<Option>, OptionManager>();
            builder.Services.AddScoped<IDataRepository<Pack>, PackManager>();
            builder.Services.AddScoped<IDataRepository<Parametre>, ParametreManager>();
            builder.Services.AddScoped<IDataRepository<Pays>, PaysManager>();
            builder.Services.AddScoped<IDataRepository<Prefere>, PrefereManager>();
            builder.Services.AddScoped<IDataRepository<PresentationEquipement>, PresentationEquipementManager>();
            builder.Services.AddScoped<IDataRepository<Prive>, PriveManager>();
            builder.Services.AddScoped<IDataRepository<Professionnel>, ProfessionnelManager>();
            builder.Services.AddScoped<IDataRepository<Reservation>, ReservationManager>();
            builder.Services.AddScoped<IDataRepository<SeCompose>, SeComposeManager>();
            builder.Services.AddScoped<IDataRepository<Specifie>, SpecifieManager>();
            builder.Services.AddScoped<IDataRepository<Stock>, StockManager>();
            builder.Services.AddScoped<IDataRepository<Style>, StyleManager>();
            builder.Services.AddScoped<IDataRepository<Taille>, TailleManager>();
            builder.Services.AddScoped<IDataRepository<Telephone>, TelephoneManager>();
            builder.Services.AddScoped<IDataRepository<Transaction>, TransactionManager>();
            builder.Services.AddScoped<IDataRepository<User>, UserManager>();

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Type0, Policies.Type0Policy());
                config.AddPolicy(Policies.Type1, Policies.Type1Policy());
                config.AddPolicy(Policies.Type2, Policies.Type2Policy());
            });



            // services.AddResponseCaching();  

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowAll");

            app.Run();
        }
    }
}