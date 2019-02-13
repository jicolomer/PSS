using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PSS.Models
{
    public class Empresa
    {

        public int EmpresaId { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El campo debe tener 9 caracteres")]
        public string CIF { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Contacto { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string EmailContacto { get; set; }


        public Boolean Estado { get; set; }

    }
}

