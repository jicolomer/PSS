using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PSS.Models
{
    public class Fases
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public string IdFase { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string Fase { get; set; }

    }
}
