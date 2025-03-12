using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("pulse_aggregates")]
[Index("Bucket", "Period", "Type", "Aggregate", "KeyHash", Name = "pulse_aggregates_bucket_period_type_aggregate_key_hash_unique", IsUnique = true)]
[Index("Period", "Bucket", Name = "pulse_aggregates_period_bucket_index")]
[Index("Period", "Type", "Aggregate", "Bucket", Name = "pulse_aggregates_period_type_aggregate_bucket_index")]
[Index("Type", Name = "pulse_aggregates_type_index")]
public partial class PulseAggregate
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("bucket")]
    public int Bucket { get; set; }

    [Column("period")]
    public int Period { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string Type { get; set; } = null!;

    [Column("key")]
    public string Key { get; set; } = null!;

    [Column("key_hash")]
    public Guid KeyHash { get; set; }

    [Column("aggregate")]
    [StringLength(255)]
    public string Aggregate { get; set; } = null!;

    [Column("value")]
    [Precision(20, 2)]
    public decimal Value { get; set; }

    [Column("count")]
    public int? Count { get; set; }
}
