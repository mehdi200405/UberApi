using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("reservation")]
public partial class Reservation
{
    [Key]
    [Column("idreservation")]
    public int Idreservation { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("datereservation")]
    public DateOnly? Datereservation { get; set; }

    [Column("heurereservation")]
    public TimeOnly? Heurereservation { get; set; }

    [Column("pourqui")]
    [StringLength(100)]
    public string? Pourqui { get; set; }

    [InverseProperty("IdreservationNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("IdreservationNavigation")]
    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    [ForeignKey("Idclient")]
    [InverseProperty("Reservations")]
    public virtual Client IdclientNavigation { get; set; } = null!;

    [InverseProperty("IdreservationVeloNavigation")]
    public virtual ICollection<VeloReservation> VeloReservations { get; set; } = new List<VeloReservation>();
}
