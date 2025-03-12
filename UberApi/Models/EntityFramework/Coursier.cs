using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("coursier")]
[Index("Iban", Name = "uq_coursier_iban", IsUnique = true)]
[Index("Emailuser", Name = "uq_coursier_mail", IsUnique = true)]
[Index("Numerocartevtc", Name = "uq_coursier_numcarte", IsUnique = true)]
public partial class Coursier
{
    [Key]
    [Column("idcoursier")]
    public int Idcoursier { get; set; }

    [Column("identreprise")]
    public int Identreprise { get; set; }

    [Column("idadresse")]
    public int? Idadresse { get; set; }

    [Column("genreuser")]
    [StringLength(20)]
    public string Genreuser { get; set; } = null!;

    [Column("nomuser")]
    [StringLength(50)]
    public string Nomuser { get; set; } = null!;

    [Column("prenomuser")]
    [StringLength(50)]
    public string Prenomuser { get; set; } = null!;

    [Column("datenaissance")]
    public DateOnly Datenaissance { get; set; }

    [Column("telephone")]
    [StringLength(20)]
    public string Telephone { get; set; } = null!;

    [Column("emailuser")]
    [StringLength(200)]
    public string Emailuser { get; set; } = null!;

    [Column("motdepasseuser")]
    [StringLength(200)]
    public string Motdepasseuser { get; set; } = null!;

    [Column("numerocartevtc")]
    [StringLength(12)]
    public string Numerocartevtc { get; set; } = null!;

    [Column("iban")]
    [StringLength(30)]
    public string? Iban { get; set; }

    [Column("datedebutactivite")]
    public DateOnly? Datedebutactivite { get; set; }

    [Column("notemoyenne")]
    [Precision(2, 1)]
    public decimal? Notemoyenne { get; set; }

    [InverseProperty("IdcoursierNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("IdcoursierNavigation")]
    public virtual ICollection<Entretien> Entretiens { get; set; } = new List<Entretien>();

    [InverseProperty("IdcoursierNavigation")]
    public virtual ICollection<Horaire> Horaires { get; set; } = new List<Horaire>();

    [ForeignKey("Idadresse")]
    [InverseProperty("Coursiers")]
    public virtual Adresse? IdadresseNavigation { get; set; }

    [ForeignKey("Identreprise")]
    [InverseProperty("Coursiers")]
    public virtual Entreprise IdentrepriseNavigation { get; set; } = null!;

    [InverseProperty("IdcoursierNavigation")]
    public virtual ICollection<ReglementSalaire> ReglementSalaires { get; set; } = new List<ReglementSalaire>();

    [InverseProperty("IdcoursierNavigation")]
    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}
