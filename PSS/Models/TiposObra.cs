using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PSS.Models
{
    public class TiposObra
    {
        [Key]
        public string IdTipoObra { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 250 caracteres")]
        public string TipoObra { get; set; }
    }
}
