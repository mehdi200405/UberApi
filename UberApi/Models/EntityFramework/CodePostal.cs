using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_code_postal_cp")]
[Index("Codepostal", Name = "uq_codepostal", IsUnique = true)]
public partial class Code_Postal
{
    [Key]
    [Column("cp_id")]
    public int IdCodePostal { get; set; }

    [Column("pa_idpays")]
    public int? IdPays { get; set; }

    [Column("cp_codepostal")]
    [StringLength(5)]
    public string CodePostal { get; set; } = null!;

    [ForeignKey("Idpays")]
    [InverseProperty("CodePostals")]
    public virtual Pays? IdPaysNavigation { get; set; }

    [InverseProperty("IdcodepostalNavigation")]
    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
