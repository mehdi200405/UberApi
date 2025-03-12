using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("pulse_values")]
[Index("Timestamp", Name = "pulse_values_timestamp_index")]
[Index("Type", Name = "pulse_values_type_index")]
[Index("Type", "KeyHash", Name = "pulse_values_type_key_hash_unique", IsUnique = true)]
public partial class PulseValue
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("timestamp")]
    public int Timestamp { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string Type { get; set; } = null!;

    [Column("key")]
    public string Key { get; set; } = null!;

    [Column("key_hash")]
    public Guid KeyHash { get; set; }

    [Column("value")]
    public string Value { get; set; } = null!;
}
