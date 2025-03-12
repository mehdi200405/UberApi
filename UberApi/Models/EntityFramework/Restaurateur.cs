using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("restaurateur")]
[Index("Emailuser", Name = "uq_restaurateur_mail", IsUnique = true)]
public partial class Restaurateur
{
    [Key]
    [Column("idrestaurateur")]
    public int Idrestaurateur { get; set; }

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

    [InverseProperty("IdrestaurateurNavigation")]
    public virtual ICollection<Etablissement> Etablissements { get; set; } = new List<Etablissement>();
}
