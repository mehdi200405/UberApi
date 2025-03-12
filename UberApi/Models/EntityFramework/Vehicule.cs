using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_vehicule_vcl")]
[Index("vcl_immatriculation", Name = "uq_vehicule_immatriculation", IsUnique = true)]
public partial class Vehicule
{
    [Key]
    [Column("vcl_idvehicule")]
    public int IdVehicule { get; set; }

    [Column("csr_idcoursier")]
    public int IdCoursier { get; set; }

    [Column("vcl_immatriculation")]
    [StringLength(9)]
    public string Immatriculation { get; set; } = null!;

    [Column("vcl_marque")]
    [StringLength(50)]
    public string? Marque { get; set; }

    [Column("vcl_modele")]
    [StringLength(50)]
    public string? Modele { get; set; }

    [Column("vcl_capacite")]
    public int? Capacite { get; set; }

    [Column("vcl_accepteanimaux")]
    public bool AccepteAnimaux { get; set; }

    [Column("vcl_estelectrique")]
    public bool EstElectrique { get; set; }

    [Column("vcl_estrecent")]
    public bool EstConfortable { get; set; }

    [Column("vcl_estrecent")]
    public bool EstRecent { get; set; }

    [Column("vcl_estluxueux")]
    public bool EstLuxueux { get; set; }

    [Column("vcl_couleur")]
    [StringLength(20)]
    public string? Couleur { get; set; }

    [Column("vcl_statusprocessuslogistique")]
    [StringLength(50)]
    public string StatusProcessusLogistique { get; set; } = null!;

    [Column("vcl_demandemodification")]
    public string? DemandeModification { get; set; }

    [Column("vcl_demandemodificationeffectue")]
    public bool DemandeModificationeffectue { get; set; }

    [ForeignKey("vcl_idcoursier")]
    [InverseProperty("IdCoursierNavigation")]
    public virtual Coursier IdCoursierNavigation { get; set; } = null!;

    [ForeignKey("vcl_idvehicule")]
    [InverseProperty("IdPrestations")]
    public virtual ICollection<TypePrestation> IdPrestations { get; set; } = new List<TypePrestation>();
}
