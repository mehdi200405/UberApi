using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("livreur")]
[Index("Iban", Name = "uq_livreur_iban", IsUnique = true)]
[Index("EmailUser", Name = "uq_livreur_mail", IsUnique = true)]
public partial class Livreur
{
    [Key]
    [Column("idlivreur")]
    public int Idlivreur { get; set; }

    [Column("identreprise")]
    public int Identreprise { get; set; }

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

    [Column("iban")]
    [StringLength(30)]
    public string? Iban { get; set; }

    [Column("datedebutactivite")]
    public DateOnly? Datedebutactivite { get; set; }

    [Column("notemoyenne")]
    [Precision(2, 1)]
    public decimal? Notemoyenne { get; set; }

    [InverseProperty("IdlivreurNavigation")]
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    [InverseProperty("IdlivreurNavigation")]
    public virtual ICollection<Horaire> Horaires { get; set; } = new List<Horaire>();
}
