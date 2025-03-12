using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("lieu_favori")]
public partial class LieuFavori
{
    [Key]
    [Column("idlieufavori")]
    public int Idlieufavori { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("idadresse")]
    public int Idadresse { get; set; }

    [Column("nomlieu")]
    [StringLength(100)]
    public string Nomlieu { get; set; } = null!;

    [ForeignKey("Idadresse")]
    [InverseProperty("LieuFavoris")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [ForeignKey("Idclient")]
    [InverseProperty("LieuFavoris")]
    public virtual Client IdclientNavigation { get; set; } = null!;
}
