using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("categorie_prestation")]
public partial class CategoriePrestation
{
    [Key]
    [Column("idcategorieprestation")]
    public int Idcategorieprestation { get; set; }

    [Column("libellecategorieprestation")]
    [StringLength(50)]
    public string? Libellecategorieprestation { get; set; }

    [Column("descriptioncategorieprestation")]
    [StringLength(500)]
    public string? Descriptioncategorieprestation { get; set; }

    [Column("imagecategorieprestation")]
    [StringLength(300)]
    public string? Imagecategorieprestation { get; set; }

    [ForeignKey("Idcategorieprestation")]
    [InverseProperty("Idcategorieprestations")]
    public virtual ICollection<Etablissement> Idetablissements { get; set; } = new List<Etablissement>();
}
