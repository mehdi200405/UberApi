using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_velo_vel")]
[Index("Numerovelo", Name = "uq_velo_numero", IsUnique = true)]
public partial class Velo
{
    [Key]
    [Column("vel_id")]
    public int Idvelo { get; set; }

    [Column("adr_idadresse")]
    public int Idadresse { get; set; }

    [Column("vel_numero")]
    public int Numerovelo { get; set; }

    [Column("vel_estdisponible")]
    public bool Estdisponible { get; set; }

    [ForeignKey("Idadresse")]
    [InverseProperty("Velos")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [InverseProperty("IdveloNavigation")]
    public virtual ICollection<VeloReservation> VeloReservations { get; set; } = new List<VeloReservation>();
}
