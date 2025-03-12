using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("course")]
public partial class Course
{
    [Key]
    [Column("idcourse")]
    public int Idcourse { get; set; }

    [Column("idcoursier")]
    public int? Idcoursier { get; set; }

    [Column("idcb")]
    public int Idcb { get; set; }

    [Column("idadresse")]
    public int Idadresse { get; set; }

    [Column("idreservation")]
    public int Idreservation { get; set; }

    [Column("adr_idadresse")]
    public int AdrIdadresse { get; set; }

    [Column("idprestation")]
    public int Idprestation { get; set; }

    [Column("datecourse")]
    public DateOnly Datecourse { get; set; }

    [Column("heurecourse")]
    public TimeOnly Heurecourse { get; set; }

    [Column("prixcourse")]
    [Precision(8, 2)]
    public decimal Prixcourse { get; set; }

    [Column("statutcourse")]
    [StringLength(20)]
    public string Statutcourse { get; set; } = null!;

    [Column("notecourse")]
    [Precision(2, 1)]
    public decimal? Notecourse { get; set; }

    [Column("commentairecourse")]
    [StringLength(1500)]
    public string? Commentairecourse { get; set; }

    [Column("pourboire")]
    [Precision(8, 2)]
    public decimal? Pourboire { get; set; }

    [Column("distance")]
    [Precision(8, 2)]
    public decimal? Distance { get; set; }

    [Column("temps")]
    public int? Temps { get; set; }

    [ForeignKey("AdrIdadresse")]
    [InverseProperty("CourseAdrIdadresseNavigations")]
    public virtual Adresse AdrIdadresseNavigation { get; set; } = null!;

    [ForeignKey("Idadresse")]
    [InverseProperty("CourseIdadresseNavigations")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [ForeignKey("Idcb")]
    [InverseProperty("Courses")]
    public virtual CarteBancaire IdcbNavigation { get; set; } = null!;

    [ForeignKey("Idcoursier")]
    [InverseProperty("Courses")]
    public virtual Coursier? IdcoursierNavigation { get; set; }

    [ForeignKey("Idprestation")]
    [InverseProperty("Courses")]
    public virtual TypePrestation IdprestationNavigation { get; set; } = null!;

    [ForeignKey("Idreservation")]
    [InverseProperty("Courses")]
    public virtual Reservation IdreservationNavigation { get; set; } = null!;
}
