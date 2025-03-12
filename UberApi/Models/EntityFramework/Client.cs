using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("client")]
[Index("EmailUser", Name = "uq_client_mail", IsUnique = true)]
public partial class Client
{
    [Key]
    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("identreprise")]
    public int? Identreprise { get; set; }

    [Column("IdAdresse")]
    public int? IdAdresse { get; set; }

    [Column("genreuser")]
    [StringLength(20)]
    public string Genreuser { get; set; } = null!;

    [Column("NomUser")]
    [StringLength(50)]
    public string NomUser { get; set; } = null!;

    [Column("PrenomUser")]
    [StringLength(50)]
    public string PrenomUser { get; set; } = null!;

    [Column("datenaissance")]
    public DateOnly Datenaissance { get; set; }

    [Column("telephone")]
    [StringLength(20)]
    public string Telephone { get; set; } = null!;

    [Column("EmailUser")]
    [StringLength(200)]
    public string EmailUser { get; set; } = null!;

    [Column("MotDePasseUser")]
    [StringLength(200)]
    public string MotDePasseUser { get; set; } = null!;

    [Column("photoprofile")]
    [StringLength(300)]
    public string? Photoprofile { get; set; }

    [Column("souhaiterecevoirbonplan")]
    public bool? Souhaiterecevoirbonplan { get; set; }

    [Column("mfa_activee")]
    public bool? MfaActivee { get; set; }

    [Column("typeclient")]
    [StringLength(20)]
    public string Typeclient { get; set; } = null!;

    [Column("last_connexion", TypeName = "timestamp without time zone")]
    public DateTime? LastConnexion { get; set; }

    [Column("demande_suppression")]
    public bool? DemandeSuppression { get; set; }

    [InverseProperty("IdclientNavigation")]
    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    [ForeignKey("IdAdresse")]
    [InverseProperty("Clients")]
    public virtual Adresse? IdAdresseNavigation { get; set; }

    [ForeignKey("Identreprise")]
    [InverseProperty("Clients")]
    public virtual Entreprise? IdentrepriseNavigation { get; set; }

    [InverseProperty("IdclientNavigation")]
    public virtual ICollection<LieuFavori> LieuFavoris { get; set; } = new List<LieuFavori>();

    [InverseProperty("IdclientNavigation")]
    public virtual ICollection<Otp> Otps { get; set; } = new List<Otp>();

    [InverseProperty("IdclientNavigation")]
    public virtual ICollection<Panier> Paniers { get; set; } = new List<Panier>();

    [InverseProperty("IdclientNavigation")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [ForeignKey("Idclient")]
    [InverseProperty("Idclients")]
    public virtual ICollection<CarteBancaire> Idcbs { get; set; } = new List<CarteBancaire>();
}
