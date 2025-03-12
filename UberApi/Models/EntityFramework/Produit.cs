using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("produit")]
public partial class Produit
{
    [Key]
    [Column("idproduit")]
    public int Idproduit { get; set; }

    [Column("nomproduit")]
    [StringLength(200)]
    public string? Nomproduit { get; set; }

    [Column("prixproduit")]
    [Precision(5, 2)]
    public decimal? Prixproduit { get; set; }

    [Column("imageproduit")]
    [StringLength(300)]
    public string? Imageproduit { get; set; }

    [Column("description")]
    [StringLength(1500)]
    public string? Description { get; set; }

    [InverseProperty("IdproduitNavigation")]
    public virtual ICollection<Contient2> Contient2s { get; set; } = new List<Contient2>();

    [ForeignKey("Idproduit")]
    [InverseProperty("Idproduits")]
    public virtual ICollection<CategorieProduit> Idcategories { get; set; } = new List<CategorieProduit>();

    [ForeignKey("Idproduit")]
    [InverseProperty("Idproduits")]
    public virtual ICollection<Etablissement> Idetablissements { get; set; } = new List<Etablissement>();
}
