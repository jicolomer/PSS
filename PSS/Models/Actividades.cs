using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PSS.Models
{
    public class Actividades
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int IdFase { get; set; }


        [StringLength(3, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 caracteres")]
        public string IdActividad { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Actividad { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Descripcion { get; set; }

    }
}
