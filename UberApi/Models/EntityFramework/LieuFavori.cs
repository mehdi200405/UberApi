using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_lieufavori_lfs")]
public partial class LieuFavori
{
    [Key]
    [Column("idlieufavori")]
    public int IdLieuFavori { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("IdAdresse")]
    public int IdAdresse { get; set; }

    [Column("nomlieu")]
    [StringLength(100)]
    public string Nomlieu { get; set; } = null!;

    [ForeignKey("IdAdresse")]
    [InverseProperty("LieuFavoris")]
    public virtual Adresse IdAdresseNavigation { get; set; } = null!;

    [ForeignKey("Idclient")]
    [InverseProperty("LieuFavoris")]
    public virtual Client IdclientNavigation { get; set; } = null!;
}
