using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static UberApi.Models.EntityFramework.Vehicule;

namespace UberApi.Models.EntityFramework
{
    [PrimaryKey(nameof(IdVehicule),nameof(IdCoureur))]
    [Table("t_e_vehicule_vcl")]
    public partial class Vehicule
    {
        [Key]
        [Column("vcl_idvehicule")]
        public int IdVehicule { get; set; }
        [Key]
        [Column("vcl_idcoureur")]
        public int IdCoureur { get; set; }
        [Key]
        [Column("flm_resume")]
        public String? Resume { get; set; }
        [Key]
        [Column("flm_datesortie")]
        public DateTime DateSortie { get; set; }
        [Key]
        [Column("flm_duree", TypeName = "numeric(3,0")]
        public decimal Duree { get; set; }
        


    }
}