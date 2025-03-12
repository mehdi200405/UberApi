using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("code_postal")]
[Index("Codepostal", Name = "uq_codepostal", IsUnique = true)]
public partial class CodePostal
{
    [Key]
    [Column("idcodepostal")]
    public int Idcodepostal { get; set; }

    [Column("idpays")]
    public int? Idpays { get; set; }

    [Column("codepostal")]
    [StringLength(5)]
    public string Codepostal { get; set; } = null!;

    [ForeignKey("Idpays")]
    [InverseProperty("CodePostals")]
    public virtual Pay? IdpaysNavigation { get; set; }

    [InverseProperty("IdcodepostalNavigation")]
    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
