using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("t_e_type_prestation_tpn")]
public partial class TypePrestation
{
    [Key]
    [Column("tpn_id")]
    public int IdPrestation { get; set; }

    [Column("tpn_libelleprestation")]
    [StringLength(50)]
    public string? LibellePrestation { get; set; }

    [Column("tpn_descriptionprestation")]
    [StringLength(500)]
    public string? DescriptionPrestation { get; set; }

    [Column("tpn_imageprestation")]
    [StringLength(300)]
    public string? ImagePrestation { get; set; }

    [InverseProperty("crs_id")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("vcl_id")]
    [InverseProperty("IdPrestations")]
    public virtual ICollection<Vehicule> IdVehicules { get; set; } = new List<Vehicule>();
}
