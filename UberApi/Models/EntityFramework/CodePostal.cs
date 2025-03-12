using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_code_postal_cp")]
[Index("Codepostal", Name = "uq_codepostal", IsUnique = true)]
public partial class CodePostal
{
    [Key]
    [Column("cp_id")]
    public int Idcodepostal { get; set; }

    [Column("pa_idpays")]
    public int? Idpays { get; set; }

    [Column("cp_codepostal")]
    [StringLength(5)]
    public string Codepostal { get; set; } = null!;

    [ForeignKey("Idpays")]
    [InverseProperty("CodePostals")]
    public virtual Pays? IdpaysNavigation { get; set; }

    [InverseProperty("IdcodepostalNavigation")]
    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
