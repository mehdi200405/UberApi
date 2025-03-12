using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_horaire_hor")]
public partial class Horaire
{
    [Key]
    [Column("hor_idhoraires")]
    public int IdHoraires { get; set; }

    [Column("eta_idetablissement")]
    public int? IdEtablissement { get; set; }

    [Column("cour_idcoursier")]
    public int? IdCoursier { get; set; }

    [Column("livr_idlivreur")]
    public int? IdLivreur { get; set; }

    [Column("hor_joursemaine")]
    [StringLength(9)]
    public string JourSemaine { get; set; } = null!;

    [Column("hor_heuredebut", TypeName = "time with time zone")]
    public DateTimeOffset? HeureDebut { get; set; }

    [Column("hor_heurefin", TypeName = "time with time zone")]
    public DateTimeOffset? HeureFin { get; set; }

    [ForeignKey("cour_idcoursier")]
    [InverseProperty("Horaires")]
    public virtual Coursier? IdCoursierNavigation { get; set; }

    [ForeignKey("eta_idetablissement")]
    [InverseProperty("Horaires")]
    public virtual Etablissement? IdEtablissementNavigation { get; set; }

    [ForeignKey("livr_idlivreur")]
    [InverseProperty("Horaires")]
    public virtual Livreur? IdLivreurNavigation { get; set; }
}