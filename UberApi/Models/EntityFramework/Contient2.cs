﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[PrimaryKey("Idpanier", "Idproduit")]
[Table("contient_2")]
public partial class Contient2
{
    [Key]
    [Column("idpanier")]
    public int Idpanier { get; set; }

    [Key]
    [Column("idproduit")]
    public int Idproduit { get; set; }

    [Column("IdEtablissement")]
    public int IdEtablissement { get; set; }

    [Column("quantite")]
    public int Quantite { get; set; }

    [ForeignKey("IdEtablissement")]
    [InverseProperty("Contient2s")]
    public virtual Etablissement IdEtablissementNavigation { get; set; } = null!;

    [ForeignKey("Idpanier")]
    [InverseProperty("Contient2s")]
    public virtual Panier IdpanierNavigation { get; set; } = null!;

    [ForeignKey("Idproduit")]
    [InverseProperty("Contient2s")]
    public virtual Produit IdproduitNavigation { get; set; } = null!;
}
