using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("horaires")]
public partial class Horaire
{
    [Key]
    [Column("idhoraires")]
    public int Idhoraires { get; set; }

    [Column("idetablissement")]
    public int? Idetablissement { get; set; }

    [Column("idcoursier")]
    public int? Idcoursier { get; set; }

    [Column("idlivreur")]
    public int? Idlivreur { get; set; }

    [Column("joursemaine")]
    [StringLength(9)]
    public string Joursemaine { get; set; } = null!;

    [Column("heuredebut", TypeName = "time with time zone")]
    public DateTimeOffset? Heuredebut { get; set; }

    [Column("heurefin", TypeName = "time with time zone")]
    public DateTimeOffset? Heurefin { get; set; }

    [ForeignKey("Idcoursier")]
    [InverseProperty("Horaires")]
    public virtual Coursier? IdcoursierNavigation { get; set; }

    [ForeignKey("Idetablissement")]
    [InverseProperty("Horaires")]
    public virtual Etablissement? IdetablissementNavigation { get; set; }

    [ForeignKey("Idlivreur")]
    [InverseProperty("Horaires")]
    public virtual Livreur? IdlivreurNavigation { get; set; }
}
