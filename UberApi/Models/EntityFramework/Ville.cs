using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_ville_vil")]
public partial class Ville
{
    [Key]
    [Column("vil_id")]
    public int Idville { get; set; }

    [Column("pa_idpays")]
    public int? Idpays { get; set; }

    [Column("cp_idcodepostal")]
    public int? Idcodepostal { get; set; }

    [Column("vil_nom")]
    [StringLength(50)]
    public string Nomville { get; set; } = null!;

    [InverseProperty("IdvilleNavigation")]
    public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

    [ForeignKey("Idcodepostal")]
    [InverseProperty("Villes")]
    public virtual CodePostal? IdcodepostalNavigation { get; set; }

    [ForeignKey("Idpays")]
    [InverseProperty("Villes")]
    public virtual Pays? IdpaysNavigation { get; set; }
}
