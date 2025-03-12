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
    public int IdFacture { get; set; }

    [Column("res_idreservation")]
    public int? IdReservation { get; set; }

    [Column("cmd_id")]
    public int? IdCommande { get; set; }

    [Column("pys_idpays")]
    public int IdPays { get; set; }

    [Column("clt_idclient")]
    public int IdClient { get; set; }

    [Column("fac_montantreglement")]
    [Precision(5, 2)]
    public decimal? MontantReglement { get; set; }

    [Column("fac_datefacture")]
    public DateOnly? DateFacture { get; set; }

    [Column("fac_quantite")]
    public int? Quantite { get; set; }

    [ForeignKey("Idclient")]
    [InverseProperty("Factures")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("Idcommande")]
    [InverseProperty("Factures")]
    public virtual Commande? IdCommandeNavigation { get; set; }

    [ForeignKey("Idpays")]
    [InverseProperty("Factures")]
    public virtual Pays IdPaysNavigation { get; set; } = null!;

    [ForeignKey("Idreservation")]
    [InverseProperty("Factures")]
    public virtual Reservation? IdReservationNavigation { get; set; }
}
