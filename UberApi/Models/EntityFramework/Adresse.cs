using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("adresse")]
public partial class Adresse
{
    [Key]
    [Column("IdAdresse")]
    public int IdAdresse { get; set; }

    [Column("idville")]
    public int? Idville { get; set; }

    [Column("libelleadresse")]
    [StringLength(100)]
    public string Libelleadresse { get; set; } = null!;

    [Column("latitude")]
    [StringLength(100)]
    public string? Latitude { get; set; }

    [Column("longitude")]
    [StringLength(100)]
    public string? Longitude { get; set; }

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("AdrIdAdresseNavigation")]
    public virtual ICollection<Course> CourseAdrIdAdresseNavigations { get; set; } = new List<Course>();

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Course> CourseIdAdresseNavigations { get; set; } = new List<Course>();

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Coursier> Coursiers { get; set; } = new List<Coursier>();

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Entreprise> Entreprises { get; set; } = new List<Entreprise>();

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Etablissement> Etablissements { get; set; } = new List<Etablissement>();

    [ForeignKey("Idville")]
    [InverseProperty("Adresses")]
    public virtual Ville? IdvilleNavigation { get; set; }

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<LieuFavori> LieuFavoris { get; set; } = new List<LieuFavori>();

    [InverseProperty("IdAdresseNavigation")]
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
}
