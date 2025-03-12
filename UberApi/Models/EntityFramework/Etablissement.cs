using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("etablissement")]
public partial class Etablissement
{
    [Key]
    [Column("idetablissement")]
    public int Idetablissement { get; set; }

    [Column("idrestaurateur")]
    public int Idrestaurateur { get; set; }

    [Column("typeetablissement")]
    [StringLength(50)]
    public string Typeetablissement { get; set; } = null!;

    [Column("idadresse")]
    public int Idadresse { get; set; }

    [Column("nometablissement")]
    [StringLength(50)]
    public string? Nometablissement { get; set; }

    [Column("description")]
    [StringLength(1500)]
    public string? Description { get; set; }

    [Column("imageetablissement")]
    [StringLength(200)]
    public string? Imageetablissement { get; set; }

    [Column("livraison")]
    public bool? Livraison { get; set; }

    [Column("aemporter")]
    public bool? Aemporter { get; set; }

    [InverseProperty("IdetablissementNavigation")]
    public virtual ICollection<Contient2> Contient2s { get; set; } = new List<Contient2>();

    [InverseProperty("IdetablissementNavigation")]
    public virtual ICollection<GestionEtablissement> GestionEtablissements { get; set; } = new List<GestionEtablissement>();

    [InverseProperty("IdetablissementNavigation")]
    public virtual ICollection<Horaire> Horaires { get; set; } = new List<Horaire>();

    [ForeignKey("Idadresse")]
    [InverseProperty("Etablissements")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [ForeignKey("Idrestaurateur")]
    [InverseProperty("Etablissements")]
    public virtual Restaurateur IdrestaurateurNavigation { get; set; } = null!;

    [ForeignKey("Idetablissement")]
    [InverseProperty("Idetablissements")]
    public virtual ICollection<CategoriePrestation> Idcategorieprestations { get; set; } = new List<CategoriePrestation>();

    [ForeignKey("Idetablissement")]
    [InverseProperty("Idetablissements")]
    public virtual ICollection<Produit> Idproduits { get; set; } = new List<Produit>();
}
