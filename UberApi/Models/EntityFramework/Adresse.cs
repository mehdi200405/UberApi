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
    [Column("idadresse")]
    public int Idadresse { get; set; }

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

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("AdrIdadresseNavigation")]
    public virtual ICollection<Course> CourseAdrIdadresseNavigations { get; set; } = new List<Course>();

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Course> CourseIdadresseNavigations { get; set; } = new List<Course>();

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Coursier> Coursiers { get; set; } = new List<Coursier>();

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Entreprise> Entreprises { get; set; } = new List<Entreprise>();

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Etablissement> Etablissements { get; set; } = new List<Etablissement>();

    [ForeignKey("Idville")]
    [InverseProperty("Adresses")]
    public virtual Ville? IdvilleNavigation { get; set; }

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<LieuFavori> LieuFavoris { get; set; } = new List<LieuFavori>();

    [InverseProperty("IdadresseNavigation")]
    public virtual ICollection<Velo> Velos { get; set; } = new List<Velo>();
}
