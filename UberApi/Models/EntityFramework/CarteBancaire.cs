using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("carte_bancaire")]
[Index("Numerocb", Name = "carte_bancaire_numerocb_key", IsUnique = true)]
public partial class CarteBancaire
{
    [Key]
    [Column("idcb")]
    public int Idcb { get; set; }

    [Column("numerocb")]
    public string Numerocb { get; set; } = null!;

    [Column("dateexpirecb")]
    public DateOnly Dateexpirecb { get; set; }

    [Column("cryptogramme")]
    public string Cryptogramme { get; set; } = null!;

    [Column("typecarte")]
    [StringLength(30)]
    public string Typecarte { get; set; } = null!;

    [Column("typereseaux")]
    [StringLength(30)]
    public string Typereseaux { get; set; } = null!;

    [InverseProperty("IdcbNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("Idcb")]
    [InverseProperty("Idcbs")]
    public virtual ICollection<Client> Idclients { get; set; } = new List<Client>();
}
