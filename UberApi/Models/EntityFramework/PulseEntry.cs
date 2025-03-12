using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("pulse_entries")]
[Index("KeyHash", Name = "pulse_entries_key_hash_index")]
[Index("Timestamp", Name = "pulse_entries_timestamp_index")]
[Index("Timestamp", "Type", "KeyHash", "Value", Name = "pulse_entries_timestamp_type_key_hash_value_index")]
[Index("Type", Name = "pulse_entries_type_index")]
public partial class PulseEntry
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
    public long? Value { get; set; }
}
