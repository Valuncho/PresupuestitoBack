﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdPerson { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]        
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string DNI { get; set; } 

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string CUIT { get; set; }

    }
}