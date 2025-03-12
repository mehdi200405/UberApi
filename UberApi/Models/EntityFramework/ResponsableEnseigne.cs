using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("responsable_enseigne")]
[Index("Emailuser", Name = "uq_responsable_email", IsUnique = true)]
public partial class ResponsableEnseigne
{
    [Key]
    [Column("idresponsable")]
    public int Idresponsable { get; set; }

    [Column("nomuser")]
    [StringLength(50)]
    public string Nomuser { get; set; } = null!;

    [Column("prenomuser")]
    [StringLength(50)]
    public string Prenomuser { get; set; } = null!;

    [Column("telephone")]
    [StringLength(20)]
    public string Telephone { get; set; } = null!;

    [Column("emailuser")]
    [StringLength(200)]
    public string Emailuser { get; set; } = null!;

    [Column("motdepasseuser")]
    [StringLength(200)]
    public string Motdepasseuser { get; set; } = null!;

    [InverseProperty("IdresponsableNavigation")]
    public virtual ICollection<GestionEtablissement> GestionEtablissements { get; set; } = new List<GestionEtablissement>();
}
