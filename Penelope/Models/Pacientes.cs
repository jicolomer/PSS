using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Penelope
{
    public partial class Pacientes
    {
        [Key]
        public int Numerohc { get; set; }
        public string Nombre { get; set; }
        public string Apellid1 { get; set; }
        public string Apellid2 { get; set; }
        public DateTime? Fechanac { get; set; }
        public int? Dni { get; set; }
        public short? Paisresi { get; set; }
        public string Domicont { get; set; }
        public int? Poblares { get; set; }
        public short? Provresi { get; set; }
        public int? Codpost { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public short? Numeross1 { get; set; }
        public int? Numeross2 { get; set; }
        public short? Numeross3 { get; set; }
        public byte Sexo { get; set; }
        public string Numtis { get; set; }
        public string Raza { get; set; }
        public short? Provinac { get; set; }
        public int? Poblanac { get; set; }
        public short? Autonaci { get; set; }
        public short? Autoresi { get; set; }
        public short? Paisnaci { get; set; }
        public short? Estcivil { get; set; }
        public string Telecont { get; set; }
        public string Estadopa { get; set; }
        public DateTime? Fecestad { get; set; }
        public string Centap { get; set; }
        public int? Historiap { get; set; }
        public string Cip { get; set; }
        public string Telefonoap { get; set; }
        public string Telreuma1 { get; set; }
        public string Telreuma1anot { get; set; }
        public string Telreuma2 { get; set; }
        public string Telreuma2anot { get; set; }
        public string Email { get; set; }
        public string Anotaciones { get; set; }
    }
}
