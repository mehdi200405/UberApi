using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[PrimaryKey("IdreservationVelo", "Idvelo")]
[Table("velo_reservation")]
public partial class VeloReservation
{
    [Key]
    [Column("idreservation_velo")]
    public int IdreservationVelo { get; set; }

    [Key]
    [Column("idvelo")]
    public int Idvelo { get; set; }

    [Column("dureereservation")]
    public int Dureereservation { get; set; }

    [Column("prixreservation")]
    [Precision(6, 2)]
    public decimal Prixreservation { get; set; }

    [ForeignKey("IdreservationVelo")]
    [InverseProperty("VeloReservations")]
    public virtual Reservation IdreservationVeloNavigation { get; set; } = null!;

    [ForeignKey("Idvelo")]
    [InverseProperty("VeloReservations")]
    public virtual Velo IdveloNavigation { get; set; } = null!;
}
