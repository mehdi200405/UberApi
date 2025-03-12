using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[PrimaryKey("IdreservationVelo", "Idvelo")]
[Table("t_e_velo_reservation_velr")]
public partial class VeloReservation
{
    [Key]
    [Column("velr_id")]
    public int IdreservationVelo { get; set; }

    [Key]
    [Column("vel_idvelo")]
    public int Idvelo { get; set; }

    [Column("velr_dureereservation")]
    public int Dureereservation { get; set; }

    [Column("velr_prixreservation")]
    [Precision(6, 2)]
    public decimal Prixreservation { get; set; }

    [ForeignKey("IdreservationVelo")]
    [InverseProperty("VeloReservations")]
    public virtual Reservation IdreservationVeloNavigation { get; set; } = null!;

    [ForeignKey("Idvelo")]
    [InverseProperty("VeloReservations")]
    public virtual Velo IdveloNavigation { get; set; } = null!;
}
