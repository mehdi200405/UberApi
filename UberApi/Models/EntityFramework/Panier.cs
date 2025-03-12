using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("panier")]
public partial class Panier
{
    [Key]
    [Column("idpanier")]
    public int Idpanier { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("prix")]
    [Precision(5, 2)]
    public decimal? Prix { get; set; }

    [InverseProperty("IdpanierNavigation")]
    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

    [InverseProperty("IdpanierNavigation")]
    public virtual ICollection<Contient2> Contient2s { get; set; } = new List<Contient2>();

    [ForeignKey("Idclient")]
    [InverseProperty("Paniers")]
    public virtual Client IdclientNavigation { get; set; } = null!;
}
