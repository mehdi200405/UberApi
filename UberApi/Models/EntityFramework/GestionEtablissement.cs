using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("gestion_etablissement")]
public partial class GestionEtablissement
{
    [Key]
    [Column("idgestion")]
    public int Idgestion { get; set; }

    [Column("idetablissement")]
    public int Idetablissement { get; set; }

    [Column("idresponsable")]
    public int Idresponsable { get; set; }

    [ForeignKey("Idetablissement")]
    [InverseProperty("GestionEtablissements")]
    public virtual Etablissement IdetablissementNavigation { get; set; } = null!;

    [ForeignKey("Idresponsable")]
    [InverseProperty("GestionEtablissements")]
    public virtual ResponsableEnseigne IdresponsableNavigation { get; set; } = null!;
}
