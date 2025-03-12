using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_facture_fac")]
public partial class Facture
{
    [Key]
    [Column("fac_id")]
    public int Idfacture { get; set; }

    [Column("res_idreservation")]
    public int? Idreservation { get; set; }

    [Column("cmd_idcommande")]
    public int? Idcommande { get; set; }

    [Column("pa_idpays")]
    public int Idpays { get; set; }

    [Column("clt_idclient")]
    public int Idclient { get; set; }

    [Column("fac_montantreglement")]
    [Precision(5, 2)]
    public decimal? Montantreglement { get; set; }

    [Column("fac_datefacture")]
    public DateOnly? Datefacture { get; set; }

    [Column("fac_quantite")]
    public int? Quantite { get; set; }

    [ForeignKey("Idclient")]
    [InverseProperty("Factures")]
    public virtual Client IdclientNavigation { get; set; } = null!;

    [ForeignKey("Idcommande")]
    [InverseProperty("Factures")]
    public virtual Commande? IdcommandeNavigation { get; set; }

    [ForeignKey("Idpays")]
    [InverseProperty("Factures")]
    public virtual Pays IdpaysNavigation { get; set; } = null!;

    [ForeignKey("Idreservation")]
    [InverseProperty("Factures")]
    public virtual Reservation? IdreservationNavigation { get; set; }
}
