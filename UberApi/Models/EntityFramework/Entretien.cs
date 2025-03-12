using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("entretien")]
public partial class Entretien
{
    [Key]
    [Column("identretien")]
    public int Identretien { get; set; }

    [Column("idcoursier")]
    public int Idcoursier { get; set; }

    [Column("dateentretien", TypeName = "timestamp without time zone")]
    public DateTime? Dateentretien { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("resultat")]
    [StringLength(20)]
    public string? Resultat { get; set; }

    [Column("rdvlogistiquedate", TypeName = "timestamp without time zone")]
    public DateTime? Rdvlogistiquedate { get; set; }

    [Column("rdvlogistiquelieu")]
    [StringLength(255)]
    public string? Rdvlogistiquelieu { get; set; }

    [ForeignKey("Idcoursier")]
    [InverseProperty("Entretiens")]
    public virtual Coursier IdcoursierNavigation { get; set; } = null!;
}
