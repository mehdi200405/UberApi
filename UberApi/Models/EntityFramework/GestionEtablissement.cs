using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_gestion_etablissement_ges")]
public partial class GestionEtablissement
{
    [Key]
    [Column("ges_id")]
    public int Idgestion { get; set; }

    [Column("etb_id")]
    public int IdEtablissement { get; set; }

    [Column("rse_id")]
    public int IdResponsable { get; set; }

    [ForeignKey("IdEtablissement")]
    [InverseProperty("GestionEtablissements")]
    public virtual Etablissement IdEtablissementNavigation { get; set; } = null!;

    [ForeignKey("IdResponsable")]
    [InverseProperty("GestionEtablissements")]
    public virtual ResponsableEnseigne IdresponsableNavigation { get; set; } = null!;
}
