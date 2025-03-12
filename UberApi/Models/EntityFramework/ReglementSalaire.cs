using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("reglement_salaire")]
public partial class ReglementSalaire
{
    [Key]
    [Column("idreglement")]
    public int Idreglement { get; set; }

    [Column("idcoursier")]
    public int? Idcoursier { get; set; }

    [Column("idlivreur")]
    public int? Idlivreur { get; set; }

    [Column("montantreglement")]
    [Precision(6, 2)]
    public decimal? Montantreglement { get; set; }

    [ForeignKey("Idcoursier")]
    [InverseProperty("ReglementSalaires")]
    public virtual Coursier? IdcoursierNavigation { get; set; }
}
