﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

public partial class S221UberContext : DbContext
{
    public S221UberContext()
    {
    }

    public S221UberContext(DbContextOptions<S221UberContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<CarteBancaire> CarteBancaires { get; set; }

    public virtual DbSet<CategoriePrestation> CategoriePrestations { get; set; }

    public virtual DbSet<CategorieProduit> CategorieProduits { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CodePostal> CodePostals { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<Contient2> Contient2s { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Coursier> Coursiers { get; set; }

    public virtual DbSet<Entreprise> Entreprises { get; set; }

    public virtual DbSet<Entretien> Entretiens { get; set; }

    public virtual DbSet<Etablissement> Etablissements { get; set; }

    public virtual DbSet<Facture> Factures { get; set; }

    public virtual DbSet<GestionEtablissement> GestionEtablissements { get; set; }

    public virtual DbSet<Horaire> Horaires { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<LieuFavori> LieuFavoris { get; set; }

    public virtual DbSet<Livreur> Livreurs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Panier> Paniers { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }
    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<PulseAggregate> PulseAggregates { get; set; }

    public virtual DbSet<PulseEntry> PulseEntries { get; set; }

    public virtual DbSet<PulseValue> PulseValues { get; set; }

    public virtual DbSet<ReglementSalaire> ReglementSalaires { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ResponsableEnseigne> ResponsableEnseignes { get; set; }

    public virtual DbSet<Restaurateur> Restaurateurs { get; set; }

    public virtual DbSet<TypePrestation> TypePrestations { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    public virtual DbSet<Velo> Velos { get; set; }

    public virtual DbSet<VeloReservation> VeloReservations { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=51.83.36.122;port=5432;Database=s221_uber; uid=s221; password=VmFu4u;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("pk_adresse");

            entity.Property(e => e.IdAdresse).HasDefaultValueSql("nextval('adresse_id_seq'::regclass)");

            entity.HasOne(d => d.IdvilleNavigation).WithMany(p => p.Adresses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_adresse_ville");
        });

        modelBuilder.Entity<CarteBancaire>(entity =>
        {
            entity.HasKey(e => e.Idcb).HasName("pk_carte_bancaire");

            entity.Property(e => e.Idcb).HasDefaultValueSql("nextval('carte_bancaire_id_seq'::regclass)");

            entity.HasMany(d => d.Idclients).WithMany(p => p.Idcbs)
                .UsingEntity<Dictionary<string, object>>(
                    "ClientCarte",
                    r => r.HasOne<Client>().WithMany()
                        .HasForeignKey("Idclient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_appartient2_client"),
                    l => l.HasOne<CarteBancaire>().WithMany()
                        .HasForeignKey("Idcb")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_appartient2_carte_bancaire"),
                    j =>
                    {
                        j.HasKey("Idcb", "Idclient").HasName("pk_client_carte");
                        j.ToTable("client_carte");
                        j.IndexerProperty<int>("Idcb").HasColumnName("idcb");
                        j.IndexerProperty<int>("Idclient").HasColumnName("idclient");
                    });
        });

        modelBuilder.Entity<CategoriePrestation>(entity =>
        {
            entity.HasKey(e => e.IdCategoriePrestation).HasName("pk_categorie_prestation");

            entity.Property(e => e.IdCategoriePrestation).HasDefaultValueSql("nextval('categorie_prestation_id_seq'::regclass)");

            entity.HasMany(d => d.IdEtablissements).WithMany(p => p.Idcategorieprestations)
                .UsingEntity<Dictionary<string, object>>(
                    "ACommeCategorie",
                    r => r.HasOne<Etablissement>().WithMany()
                        .HasForeignKey("IdEtablissement")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a_comme_categorie_etablissement"),
                    l => l.HasOne<CategoriePrestation>().WithMany()
                        .HasForeignKey("IdCategoriePrestation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a_comme_categorie_categorie"),
                    j =>
                    {
                        j.HasKey("IdCategoriePrestation", "IdEtablissement").HasName("pk_a_comme_categorie");
                        j.ToTable("a_comme_categorie");
                        j.IndexerProperty<int>("IdCategoriePrestation").HasColumnName("idcategorieprestation");
                        j.IndexerProperty<int>("IdEtablissement").HasColumnName("IdEtablissement");
                    });
        });

        modelBuilder.Entity<CategorieProduit>(entity =>
        {
            entity.HasKey(e => e.Idcategorie).HasName("pk_categorie_produit");

            entity.Property(e => e.Idcategorie).HasDefaultValueSql("nextval('categorie_produit_id_seq'::regclass)");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("pk_client");

            entity.Property(e => e.IdClient).HasDefaultValueSql("nextval('client_id_seq'::regclass)");
            entity.Property(e => e.DemandeSuppression).HasDefaultValue(false);
            entity.Property(e => e.LastConnexion).HasDefaultValueSql("now()");
            entity.Property(e => e.MfaActivee).HasDefaultValue(false);

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_client_adresse");

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_client_entreprise");
        });

        modelBuilder.Entity<CodePostal>(entity =>
        {
            entity.HasKey(e => e.Idcodepostal).HasName("pk_code_postal");

            entity.Property(e => e.Idcodepostal).HasDefaultValueSql("nextval('code_postal_id_seq'::regclass)");
            entity.Property(e => e.Codepostal).IsFixedLength();

            entity.HasOne(d => d.IdpaysNavigation).WithMany(p => p.CodePostals)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_code_postal_pays");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.Idcommande).HasName("pk_commande");

            entity.Property(e => e.Idcommande).HasDefaultValueSql("nextval('commande_id_seq'::regclass)");
            entity.Property(e => e.Estlivraison).HasDefaultValue(false);
            entity.Property(e => e.Heurecreation).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.RefusDemandee).HasDefaultValue(false);
            entity.Property(e => e.RemboursementEffectue).HasDefaultValue(false);

            entity.HasOne(d => d.IdlivreurNavigation).WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_livreur");

            entity.HasOne(d => d.IdpanierNavigation).WithMany(p => p.Commandes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_commande_panier");
        });

        modelBuilder.Entity<Contient2>(entity =>
        {
            entity.HasKey(e => new { e.Idpanier, e.Idproduit }).HasName("pk_contient_2");

            entity.Property(e => e.Quantite).HasDefaultValue(1);

            entity.HasOne(d => d.IdEtablissementNavigation).WithMany(p => p.Contient2s)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_contient2_etablissement");

            entity.HasOne(d => d.IdpanierNavigation).WithMany(p => p.Contient2s)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_contient2_panier");

            entity.HasOne(d => d.IdproduitNavigation).WithMany(p => p.Contient2s)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_contient2_produit");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Idcourse).HasName("pk_course");

            entity.Property(e => e.Idcourse).HasDefaultValueSql("nextval('course_id_seq'::regclass)");

            entity.HasOne(d => d.AdrIdAdresseNavigation).WithMany(p => p.CourseAdrIdAdresseNavigations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_adresse_depart");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.CourseIdAdresseNavigations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_adresse_arrivee");

            entity.HasOne(d => d.IdcbNavigation).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_carte_bancaire");

            entity.HasOne(d => d.IdcoursierNavigation).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_coursier");

            entity.HasOne(d => d.IdprestationNavigation).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_type_prestation");

            entity.HasOne(d => d.IdreservationNavigation).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_course_reservation");
        });

        modelBuilder.Entity<Coursier>(entity =>
        {
            entity.HasKey(e => e.Idcoursier).HasName("pk_coursier");

            entity.Property(e => e.Idcoursier).HasDefaultValueSql("nextval('coursier_id_seq'::regclass)");
            entity.Property(e => e.Numerocartevtc).IsFixedLength();

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Coursiers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_coursier_adresse");

            entity.HasOne(d => d.IdentrepriseNavigation).WithMany(p => p.Coursiers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_coursier_entreprise");
        });

        modelBuilder.Entity<Entreprise>(entity =>
        {
            entity.HasKey(e => e.Identreprise).HasName("pk_entreprise");

            entity.Property(e => e.Identreprise).HasDefaultValueSql("nextval('entreprise_id_seq'::regclass)");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Entreprises)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreprise_adresse");
        });

        modelBuilder.Entity<Entretien>(entity =>
        {
            entity.HasKey(e => e.Identretien).HasName("pk_entretien");

            entity.Property(e => e.Identretien).HasDefaultValueSql("nextval('entretien_id_seq'::regclass)");
            entity.Property(e => e.Status).HasDefaultValueSql("'En attente'::character varying");

            entity.HasOne(d => d.IdcoursierNavigation).WithMany(p => p.Entretiens)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entretien_coursier");
        });

        modelBuilder.Entity<Etablissement>(entity =>
        {
            entity.HasKey(e => e.IdEtablissement).HasName("pk_etablissement");

            entity.Property(e => e.IdEtablissement).HasDefaultValueSql("nextval('etablissement_id_seq'::regclass)");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Etablissements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_etablissement_adresse");

            entity.HasOne(d => d.IdRestaurateurNavigation).WithMany(p => p.Etablissements).HasConstraintName("fk_etablissement_restaurateur");
        });

        modelBuilder.Entity<Facture>(entity =>
        {
            entity.HasKey(e => e.Idfacture).HasName("pk_facture");

            entity.Property(e => e.Idfacture).HasDefaultValueSql("nextval('facture_id_seq'::regclass)");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Factures)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_facture_client");

            entity.HasOne(d => d.IdcommandeNavigation).WithMany(p => p.Factures)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_facture_commande");

            entity.HasOne(d => d.IdpaysNavigation).WithMany(p => p.Factures)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_facture_pays");

            entity.HasOne(d => d.IdreservationNavigation).WithMany(p => p.Factures)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_facture_reservation");
        });

        modelBuilder.Entity<GestionEtablissement>(entity =>
        {
            entity.HasKey(e => e.Idgestion).HasName("pk_gestion_etablissement");

            entity.Property(e => e.Idgestion).HasDefaultValueSql("nextval('gestion_etablissement_id_seq'::regclass)");

            entity.HasOne(d => d.IdEtablissementNavigation).WithMany(p => p.GestionEtablissements).HasConstraintName("fk_gestion_etablissement");

            entity.HasOne(d => d.IdresponsableNavigation).WithMany(p => p.GestionEtablissements).HasConstraintName("fk_gestion_responsable");
        });

        modelBuilder.Entity<Horaire>(entity =>
        {
            entity.HasKey(e => e.Idhoraires).HasName("pk_horaires");

            entity.Property(e => e.Idhoraires).HasDefaultValueSql("nextval('horaires_id_seq'::regclass)");

            entity.HasOne(d => d.IdcoursierNavigation).WithMany(p => p.Horaires)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_horaires_coursier");

            entity.HasOne(d => d.IdEtablissementNavigation).WithMany(p => p.Horaires)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_horaires_etablissement");

            entity.HasOne(d => d.IdlivreurNavigation).WithMany(p => p.Horaires)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_horaires_livreur");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");
        });

        modelBuilder.Entity<LieuFavori>(entity =>
        {
            entity.HasKey(e => e.Idlieufavori).HasName("pk_lieu_favori");

            entity.Property(e => e.Idlieufavori).HasDefaultValueSql("nextval('lieu_favori_id_seq'::regclass)");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.LieuFavoris).HasConstraintName("fk_lieu_favori_adresse");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.LieuFavoris).HasConstraintName("fk_lieu_favori_client");
        });

        modelBuilder.Entity<Livreur>(entity =>
        {
            entity.HasKey(e => e.Idlivreur).HasName("pk_livreur");

            entity.Property(e => e.Idlivreur).HasDefaultValueSql("nextval('livreur_id_seq'::regclass)");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("migrations_pkey");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.Idotp).HasName("pk_otp");

            entity.Property(e => e.Idotp).HasDefaultValueSql("nextval('otp_id_seq'::regclass)");
            entity.Property(e => e.Codeotp).IsFixedLength();
            entity.Property(e => e.Dategeneration).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Utilise).HasDefaultValue(false);

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Otps)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_otp_client");
        });

        modelBuilder.Entity<Panier>(entity =>
        {
            entity.HasKey(e => e.Idpanier).HasName("pk_panier");

            entity.Property(e => e.Idpanier).HasDefaultValueSql("nextval('panier_id_seq'::regclass)");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Paniers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_panier_client");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.Idpays).HasName("pk_pays");

            entity.Property(e => e.Idpays).HasDefaultValueSql("nextval('pays_id_seq'::regclass)");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.Idproduit).HasName("pk_produit");

            entity.Property(e => e.Idproduit).HasDefaultValueSql("nextval('produit_id_seq'::regclass)");

            entity.HasMany(d => d.Idcategories).WithMany(p => p.Idproduits)
                .UsingEntity<Dictionary<string, object>>(
                    "ProduitCategorie",
                    r => r.HasOne<CategorieProduit>().WithMany()
                        .HasForeignKey("Idcategorie")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a3_categorie_produit"),
                    l => l.HasOne<Produit>().WithMany()
                        .HasForeignKey("Idproduit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a3_produit"),
                    j =>
                    {
                        j.HasKey("Idproduit", "Idcategorie").HasName("pk_produit_categorie");
                        j.ToTable("produit_categorie");
                        j.IndexerProperty<int>("Idproduit").HasColumnName("idproduit");
                        j.IndexerProperty<int>("Idcategorie").HasColumnName("idcategorie");
                    });

            entity.HasMany(d => d.IdEtablissements).WithMany(p => p.Idproduits)
                .UsingEntity<Dictionary<string, object>>(
                    "EstSitueA2",
                    r => r.HasOne<Etablissement>().WithMany()
                        .HasForeignKey("IdEtablissement")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_est_situe2_etablissement"),
                    l => l.HasOne<Produit>().WithMany()
                        .HasForeignKey("Idproduit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_est_situe2_produit"),
                    j =>
                    {
                        j.HasKey("Idproduit", "IdEtablissement").HasName("pk_est_situe_a_2");
                        j.ToTable("est_situe_a_2");
                        j.IndexerProperty<int>("Idproduit").HasColumnName("idproduit");
                        j.IndexerProperty<int>("IdEtablissement").HasColumnName("IdEtablissement");
                    });
        });

        modelBuilder.Entity<PulseAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pulse_aggregates_pkey");

            entity.Property(e => e.KeyHash).HasComputedColumnSql("(md5(key))::uuid", true);
        });

        modelBuilder.Entity<PulseEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pulse_entries_pkey");

            entity.Property(e => e.KeyHash).HasComputedColumnSql("(md5(key))::uuid", true);
        });

        modelBuilder.Entity<PulseValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pulse_values_pkey");

            entity.Property(e => e.KeyHash).HasComputedColumnSql("(md5(key))::uuid", true);
        });

        modelBuilder.Entity<ReglementSalaire>(entity =>
        {
            entity.HasKey(e => e.Idreglement).HasName("pk_reglement_salaire");

            entity.Property(e => e.Idreglement).HasDefaultValueSql("nextval('reglement_salaire_id_seq'::regclass)");

            entity.HasOne(d => d.IdcoursierNavigation).WithMany(p => p.ReglementSalaires)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_reglement_salaire_coursier");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("pk_reservation");

            entity.Property(e => e.Idreservation).HasDefaultValueSql("nextval('reservation_id_seq'::regclass)");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Reservations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_reservation_client");
        });

        modelBuilder.Entity<ResponsableEnseigne>(entity =>
        {
            entity.HasKey(e => e.IdResponsable).HasName("pk_responsable_enseigne");

            entity.Property(e => e.IdResponsable).HasDefaultValueSql("nextval('responsable_enseigne_id_seq'::regclass)");
        });

        modelBuilder.Entity<Restaurateur>(entity =>
        {
            entity.HasKey(e => e.IdRestaurateur).HasName("pk_restaurateur");

            entity.Property(e => e.IdRestaurateur).HasDefaultValueSql("nextval('restaurateur_id_seq'::regclass)");
        });

        modelBuilder.Entity<TypePrestation>(entity =>
        {
            entity.HasKey(e => e.Idprestation).HasName("pk_type_prestation");

            entity.Property(e => e.Idprestation).HasDefaultValueSql("nextval('type_prestation_id_seq'::regclass)");
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(e => e.Idvehicule).HasName("pk_vehicule");

            entity.Property(e => e.Idvehicule).HasDefaultValueSql("nextval('vehicule_id_seq'::regclass)");
            entity.Property(e => e.Demandemodificationeffectue).HasDefaultValue(false);
            entity.Property(e => e.Immatriculation).IsFixedLength();
            entity.Property(e => e.Statusprocessuslogistique).HasDefaultValueSql("'En attente'::character varying");

            entity.HasOne(d => d.IdcoursierNavigation).WithMany(p => p.Vehicules)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_vehicule_coursier");

            entity.HasMany(d => d.Idprestations).WithMany(p => p.Idvehicules)
                .UsingEntity<Dictionary<string, object>>(
                    "ACommeType",
                    r => r.HasOne<TypePrestation>().WithMany()
                        .HasForeignKey("Idprestation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a_comme_type_type_prestation"),
                    l => l.HasOne<Vehicule>().WithMany()
                        .HasForeignKey("Idvehicule")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_a_comme_type_vehicule"),
                    j =>
                    {
                        j.HasKey("Idvehicule", "Idprestation").HasName("pk_a_comme_type");
                        j.ToTable("a_comme_type");
                        j.IndexerProperty<int>("Idvehicule").HasColumnName("idvehicule");
                        j.IndexerProperty<int>("Idprestation").HasColumnName("idprestation");
                    });
        });

        modelBuilder.Entity<Velo>(entity =>
        {
            entity.HasKey(e => e.Idvelo).HasName("pk_velo");

            entity.Property(e => e.Idvelo).HasDefaultValueSql("nextval('velo_id_seq'::regclass)");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.Velos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_velo_adresse");
        });

        modelBuilder.Entity<VeloReservation>(entity =>
        {
            entity.HasKey(e => new { e.IdreservationVelo, e.Idvelo }).HasName("pk_velo_reservation");

            entity.Property(e => e.IdreservationVelo).HasDefaultValueSql("nextval('velo_reservation_id_seq'::regclass)");

            entity.HasOne(d => d.IdreservationVeloNavigation).WithMany(p => p.VeloReservations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_velo_reservation_reservation");

            entity.HasOne(d => d.IdveloNavigation).WithMany(p => p.VeloReservations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_velo_reservation_velo");
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.Idville).HasName("pk_ville");

            entity.Property(e => e.Idville).HasDefaultValueSql("nextval('ville_id_seq'::regclass)");

            entity.HasOne(d => d.IdcodepostalNavigation).WithMany(p => p.Villes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ville_code_postal");

            entity.HasOne(d => d.IdpaysNavigation).WithMany(p => p.Villes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ville_pays");
        });
        modelBuilder.HasSequence("adresse_id_seq");
        modelBuilder.HasSequence("carte_bancaire_id_seq");
        modelBuilder.HasSequence("categorie_prestation_id_seq");
        modelBuilder.HasSequence("categorie_produit_id_seq");
        modelBuilder.HasSequence("client_id_seq");
        modelBuilder.HasSequence("code_postal_id_seq");
        modelBuilder.HasSequence("commande_id_seq");
        modelBuilder.HasSequence("course_id_seq");
        modelBuilder.HasSequence("coursier_id_seq");
        modelBuilder.HasSequence("entreprise_id_seq");
        modelBuilder.HasSequence("entretien_id_seq");
        modelBuilder.HasSequence("etablissement_id_seq");
        modelBuilder.HasSequence("facture_id_seq");
        modelBuilder.HasSequence("gestion_etablissement_id_seq");
        modelBuilder.HasSequence("horaires_id_seq");
        modelBuilder.HasSequence("lieu_favori_id_seq");
        modelBuilder.HasSequence("livreur_id_seq");
        modelBuilder.HasSequence("otp_id_seq");
        modelBuilder.HasSequence("panier_id_seq");
        modelBuilder.HasSequence("pays_id_seq");
        modelBuilder.HasSequence("planning_reservation_id_seq");
        modelBuilder.HasSequence("produit_id_seq");
        modelBuilder.HasSequence("reglement_salaire_id_seq");
        modelBuilder.HasSequence("reservation_id_seq");
        modelBuilder.HasSequence("responsable_enseigne_id_seq");
        modelBuilder.HasSequence("restaurateur_id_seq");
        modelBuilder.HasSequence("type_prestation_id_seq");
        modelBuilder.HasSequence("vehicule_id_seq");
        modelBuilder.HasSequence("velo_id_seq");
        modelBuilder.HasSequence("velo_reservation_id_seq");
        modelBuilder.HasSequence("ville_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
