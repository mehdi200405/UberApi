using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("migrations")]
public partial class Migration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("migration")]
    [StringLength(255)]
    public string Migration1 { get; set; } = null!;

    [Column("batch")]
    public int Batch { get; set; }
}
