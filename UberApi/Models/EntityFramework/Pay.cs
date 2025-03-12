using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("pays")]
[Index("Nompays", Name = "uq_nompays", IsUnique = true)]
public partial class Pay
{
    [Key]
    [Column("idpays")]
    public int Idpays { get; set; }

    [Column("nompays")]
    [StringLength(50)]
    public string Nompays { get; set; } = null!;

    [Column("pourcentagetva")]
    [Precision(4, 2)]
    public decimal? Pourcentagetva { get; set; }

    [InverseProperty("IdpaysNavigation")]
    public virtual ICollection<CodePostal> CodePostals { get; set; } = new List<CodePostal>();

    [InverseProperty("IdpaysNavigation")]
    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    [InverseProperty("IdpaysNavigation")]
    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
