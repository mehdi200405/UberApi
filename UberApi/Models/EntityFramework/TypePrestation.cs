using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("type_prestation")]
public partial class TypePrestation
{
    [Key]
    [Column("idprestation")]
    public int Idprestation { get; set; }

    [Column("libelleprestation")]
    [StringLength(50)]
    public string? Libelleprestation { get; set; }

    [Column("descriptionprestation")]
    [StringLength(500)]
    public string? Descriptionprestation { get; set; }

    [Column("imageprestation")]
    [StringLength(300)]
    public string? Imageprestation { get; set; }

    [InverseProperty("IdprestationNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("Idprestation")]
    [InverseProperty("Idprestations")]
    public virtual ICollection<Vehicule> Idvehicules { get; set; } = new List<Vehicule>();
}
