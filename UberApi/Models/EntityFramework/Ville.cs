using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("ville")]
public partial class Ville
{
    [Key]
    [Column("idville")]
    public int Idville { get; set; }

    [Column("idpays")]
    public int? Idpays { get; set; }

    [Column("idcodepostal")]
    public int? Idcodepostal { get; set; }

    [Column("nomville")]
    [StringLength(50)]
    public string Nomville { get; set; } = null!;

    [InverseProperty("IdvilleNavigation")]
    public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

    [ForeignKey("Idcodepostal")]
    [InverseProperty("Villes")]
    public virtual CodePostal? IdcodepostalNavigation { get; set; }

    [ForeignKey("Idpays")]
    [InverseProperty("Villes")]
    public virtual Pay? IdpaysNavigation { get; set; }
}
