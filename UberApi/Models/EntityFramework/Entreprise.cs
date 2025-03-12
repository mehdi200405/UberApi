using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("entreprise")]
public partial class Entreprise
{
    [Key]
    [Column("identreprise")]
    public int Identreprise { get; set; }

    [Column("IdAdresse")]
    public int IdAdresse { get; set; }

    [Column("siretentreprise")]
    [StringLength(20)]
    public string Siretentreprise { get; set; } = null!;

    [Column("nomentreprise")]
    [StringLength(50)]
    public string Nomentreprise { get; set; } = null!;

    [Column("taille")]
    [StringLength(30)]
    public string Taille { get; set; } = null!;

    [InverseProperty("IdentrepriseNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("IdentrepriseNavigation")]
    public virtual ICollection<Coursier> Coursiers { get; set; } = new List<Coursier>();

    [ForeignKey("IdAdresse")]
    [InverseProperty("Entreprises")]
    public virtual Adresse IdAdresseNavigation { get; set; } = null!;
}
