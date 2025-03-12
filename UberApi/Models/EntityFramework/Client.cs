using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UberApi.Models.EntityFramework
{
    [PrimaryKey("IdEntreprise", "IdClient", "IdAdresse")]
    [Table("t_e_client_clt")]
    public class Client
    {
        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("ent_id")]
        public int IdEntreprise { get; set; }


        [Column("clt_adresse")]
        public int IdAdresse { get; set; }

        [Column("clt_genre")]
        [StringLength(20)]
        public string GenreUser { get; set; }

        [Column("clt_nom")]
        [StringLength(50)]
        public string NomUser { get; set; }

        [Column("clt_prenom")]
        [StringLength(50)]
        public string PrenomUser { get; set; }

        [Required]
        [Column("clt_datenaissance", TypeName = "date")]
        public DateTime? DateNaissance { get; set; }

        [Column("clt_telephone", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone doit contenir 10 chiffres")]
        public string? Telephone { get; set; }


        [Required]
        [Column("clt_mail")]
        [EmailAddress]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 200 caractères.")]
        public string EmailUser { get; set; } = null!;


        [Column("clt_motdepasse")]
        [StringLength(64)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?"":{}|<>]).{12,20}$", ErrorMessage = "Le mot de passe doit contenir entre 12 et 20 caractères avec 1 lettre majuscule, 1 lettre minuscule, 1 chiffre et 1 caractère spéciale.")]
        public string MotDePasseUser { get; set; } = null!;




        [Column("clt_photo")]
        [StringLength(300)]
        public string? PhotoProfile { get; set; }


        [Column("clt_souhaiterecevoirbonplan")]
        public bool SouhaiteRecevoirBonPlan { get; set; }


        [Column("clt_mfa")]
        public bool MFA_Activee { get; set; }


        [Column("clt_type")]
        [StringLength(20)]
        public string? TypeClient { get; set; }



    }
}
