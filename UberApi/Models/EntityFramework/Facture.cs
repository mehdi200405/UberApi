using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("facture")]
public partial class Facture
{
    [Key]
    [Column("idfacture")]
    public int Idfacture { get; set; }

    [Column("idreservation")]
    public int? Idreservation { get; set; }

    [Column("idcommande")]
    public int? Idcommande { get; set; }

    [Column("idpays")]
    public int Idpays { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("montantreglement")]
    [Precision(5, 2)]
    public decimal? Montantreglement { get; set; }

    [Column("datefacture")]
    public DateOnly? Datefacture { get; set; }

    [Column("quantite")]
    public int? Quantite { get; set; }

    [ForeignKey("Idclient")]
    [InverseProperty("Factures")]
    public virtual Client IdclientNavigation { get; set; } = null!;

    [ForeignKey("Idcommande")]
    [InverseProperty("Factures")]
    public virtual Commande? IdcommandeNavigation { get; set; }

    [ForeignKey("Idpays")]
    [InverseProperty("Factures")]
    public virtual Pay IdpaysNavigation { get; set; } = null!;

    [ForeignKey("Idreservation")]
    [InverseProperty("Factures")]
    public virtual Reservation? IdreservationNavigation { get; set; }
}
