using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("vehicule")]
[Index("Immatriculation", Name = "uq_vehicule_immatriculation", IsUnique = true)]
public partial class Vehicule
{
    [Key]
    [Column("idvehicule")]
    public int Idvehicule { get; set; }

    [Column("idcoursier")]
    public int Idcoursier { get; set; }

    [Column("immatriculation")]
    [StringLength(9)]
    public string Immatriculation { get; set; } = null!;

    [Column("marque")]
    [StringLength(50)]
    public string? Marque { get; set; }

    [Column("modele")]
    [StringLength(50)]
    public string? Modele { get; set; }

    [Column("capacite")]
    public int? Capacite { get; set; }

    [Column("accepteanimaux")]
    public bool Accepteanimaux { get; set; }

    [Column("estelectrique")]
    public bool Estelectrique { get; set; }

    [Column("estconfortable")]
    public bool Estconfortable { get; set; }

    [Column("estrecent")]
    public bool Estrecent { get; set; }

    [Column("estluxueux")]
    public bool Estluxueux { get; set; }

    [Column("couleur")]
    [StringLength(20)]
    public string? Couleur { get; set; }

    [Column("statusprocessuslogistique")]
    [StringLength(50)]
    public string Statusprocessuslogistique { get; set; } = null!;

    [Column("demandemodification")]
    public string? Demandemodification { get; set; }

    [Column("demandemodificationeffectue")]
    public bool Demandemodificationeffectue { get; set; }

    [ForeignKey("Idcoursier")]
    [InverseProperty("Vehicules")]
    public virtual Coursier IdcoursierNavigation { get; set; } = null!;

    [ForeignKey("Idvehicule")]
    [InverseProperty("Idvehicules")]
    public virtual ICollection<TypePrestation> Idprestations { get; set; } = new List<TypePrestation>();
}
