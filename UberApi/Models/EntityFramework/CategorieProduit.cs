using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("categorie_produit")]
public partial class CategorieProduit
{
    [Key]
    [Column("idcategorie")]
    public int Idcategorie { get; set; }

    [Column("nomcategorie")]
    [StringLength(100)]
    public string? Nomcategorie { get; set; }

    [ForeignKey("Idcategorie")]
    [InverseProperty("Idcategories")]
    public virtual ICollection<Produit> isProduits { get; set; } = new List<Produit>();
}
