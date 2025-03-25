using Microsoft.EntityFrameworkCore;
using UberApi.Models.DataManager;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace UberApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<S221UberContext>(options =>
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).UseNpgsql(builder.Configuration.GetConnectionString("S221UberContext")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDataRepository<Client>, ClientManager>();
            builder.Services.AddScoped<IDataRepository<Coursier>, CoursierManager>();
            builder.Services.AddScoped<IDataRepository<Restaurateur>, RestaurateurManager>();
            builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
            builder.Services.AddScoped<IDataRepository<Vehicule>, VehiculeManager>();
            builder.Services.AddScoped<IDataRepository<Livreur>, LivreurManager>();
            builder.Services.AddScoped<IDataRepository<Etablissement>, EtablissementManager>();
            builder.Services.AddScoped<IDataRepository<Commande>, CommandeManager>();
            builder.Services.AddScoped<IDataRepository<Entretien>, EntretienManager>();
            builder.Services.AddScoped<IDataRepository<Entreprise>, EntrepriseManager>();
            builder.Services.AddScoped<IDataRepository<CarteBancaire>, CarteBancaireManager>();
            builder.Services.AddScoped<IDataRepository<Ville>, VilleManager>();
            builder.Services.AddScoped<IDataRepository<CodePostal>, CodePostalManager>();
            builder.Services.AddScoped<IDataRepository<Pays>, PaysManager>();
            builder.Services.AddScoped<IDataRepository<LieuFavori>, LieuFavoriManager>();
            builder.Services.AddScoped<IDataRepository<Facture>, FactureManager>();
            builder.Services.AddScoped<IDataRepository<Produit>, ProduitManager>();
            builder.Services.AddScoped<IDataRepository<CategoriePrestation>, CategoriePrestationManager>();
            builder.Services.AddScoped<IDataRepository<CategorieProduit>, CategorieProduitManager>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}