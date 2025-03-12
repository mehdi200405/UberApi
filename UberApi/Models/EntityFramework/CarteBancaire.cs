using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_carteBancaire_ctbr")]
[Index("Numerocb", Name = "carte_bancaire_numerocb_key", IsUnique = true)]
public partial class CarteBancaire
{
    [Key]
    [Column("cb_id")]
    public int IdCb { get; set; }

    [Column("cb_numerocb")]
    public string NumeroCb { get; set; } = null!;

    [Column("cb_date")]
    public DateOnly DateexpireCb { get; set; }

    [Column("cb_cryptogramme")]
    public string Cryptogramme { get; set; } = null!;

    [Column("cb_typecarte")]
    [StringLength(30)]
    public string TypeCarte { get; set; } = null!;

    [Column("cb_typereseaux")]
    [StringLength(30)]
    public string TypeReseaux { get; set; } = null!;

    [InverseProperty("IdCbNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("IdCb")]
    [InverseProperty("Idcbs")]
    public virtual ICollection<Client> IdClients { get; set; } = new List<Client>();
}
