using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SorianaApplication.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        [Key]
        public int idSucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Direccion Sucursal")]
        [Required]
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [Required]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        public string email { get; set; }
        [Display(Name = "Fecha Apertura")]
        [Required]

        public DateTime fechaApertura { get; set; }
        [Display(Name = "Estatus")]
        [Required]
        public int estatus { get; set; }

    }
}