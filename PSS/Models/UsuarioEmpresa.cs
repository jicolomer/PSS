using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSS.Models
{
    public class UsuarioEmpresa
    {
        public string Id { get; set; }
        public int EmpresaId { get; set; }

    }
}
