using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("commande")]
public partial class Commande
{
    [Key]
    [Column("idcommande")]
    public int Idcommande { get; set; }

    [Column("idpanier")]
    public int Idpanier { get; set; }

    [Column("idlivreur")]
    public int? Idlivreur { get; set; }

    [Column("idcb")]
    public int? Idcb { get; set; }

    [Column("IdAdresse")]
    public int IdAdresse { get; set; }

    [Column("prixcommande")]
    [Precision(5, 2)]
    public decimal Prixcommande { get; set; }

    [Column("tempscommande")]
    public int Tempscommande { get; set; }

    [Column("heurecreation", TypeName = "timestamp without time zone")]
    public DateTime Heurecreation { get; set; }

    [Column("heurecommande", TypeName = "timestamp without time zone")]
    public DateTime Heurecommande { get; set; }

    [Column("estlivraison")]
    public bool Estlivraison { get; set; }

    [Column("statutcommande")]
    [StringLength(40)]
    public string Statutcommande { get; set; } = null!;

    [Column("refus_demandee")]
    public bool RefusDemandee { get; set; }

    [Column("remboursement_effectue")]
    public bool RemboursementEffectue { get; set; }

    [InverseProperty("IdcommandeNavigation")]
    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();

    [ForeignKey("Idlivreur")]
    [InverseProperty("Commandes")]
    public virtual Livreur? IdlivreurNavigation { get; set; }

    [ForeignKey("Idpanier")]
    [InverseProperty("Commandes")]
    public virtual Panier IdpanierNavigation { get; set; } = null!;
}
