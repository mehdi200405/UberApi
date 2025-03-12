﻿using System;
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
    public int IdCodePostal { get; set; }

    [Column("pa_idpays")]
    public int? IdPays { get; set; }

    [Column("cp_cp")]
    [StringLength(5)]
    public string CP { get; set; } = null!;

    [ForeignKey("IdPays")]
    [InverseProperty("CodePostals")]
    public virtual Pays? IdPaysNavigation { get; set; }

    [InverseProperty("IdCodePostalNavigation")]
    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
