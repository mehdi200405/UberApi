using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("velo")]
[Index("Numerovelo", Name = "uq_velo_numero", IsUnique = true)]
public partial class Velo
{
    [Key]
    [Column("idvelo")]
    public int Idvelo { get; set; }

    [Column("idadresse")]
    public int Idadresse { get; set; }

    [Column("numerovelo")]
    public int Numerovelo { get; set; }

    [Column("estdisponible")]
    public bool Estdisponible { get; set; }

    [ForeignKey("Idadresse")]
    [InverseProperty("Velos")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [InverseProperty("IdveloNavigation")]
    public virtual ICollection<VeloReservation> VeloReservations { get; set; } = new List<VeloReservation>();
}
