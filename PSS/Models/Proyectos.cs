using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public partial class Proyectos
    {
        [Key]
        public int IdObra { get; set; }
        public int IdEmpre { get; set; }
        public string NombreObra { get; set; }
        public string NumOt { get; set; }
        public string Cliente { get; set; }
        public string DireccionObra { get; set; }
        public string CiudadObra { get; set; }
        public string ProvinciaObra { get; set; }
        public string CpObra { get; set; }
        public string Promotor { get; set; }
        public string AutorProyecto { get; set; }
        public string Tecnico { get; set; }
        public string PemPec { get; set; }
        public decimal? Presupuesto { get; set; }
        public int? Duracion { get; set; }
        public string Autor { get; set; }
        public string CssfaseProyecto { get; set; }
        public int? NumTrabajadores { get; set; }
        public string Contratista { get; set; }
        public string DireccionContratista { get; set; }
        public string CiudadContratista { get; set; }
        public string ProvinciaContratista { get; set; }
        public string CpContratista { get; set; }
        public string JefeObra { get; set; }
        public string Encargado { get; set; }
        public string RecursoPreventivo { get; set; }
        public string TipoObra { get; set; }
        public string DescripcionObra { get; set; }
        public string DescripcionLugar { get; set; }
        public string Superficie { get; set; }
        public string LinderoNorte { get; set; }
        public string LinderoSur { get; set; }
        public string LinderoEste { get; set; }
        public string LinderoOeste { get; set; }
        public string TraficoRodado { get; set; }
        public string Climatologia { get; set; }
        public string CaracteristicasTerreno { get; set; }
        public bool AccesosRodados { get; set; }
        public bool CirculacionesPeatonales { get; set; }
        public bool LinElectAereas { get; set; }
        public bool LinElectEnterradas { get; set; }
        public bool Transformadores { get; set; }
        public bool LineasTelefonicas { get; set; }
        public bool ConduccionesGas { get; set; }
        public bool Alcantarillado { get; set; }
        public bool InstProviAreasAux { get; set; }
        public string TipoEstudio { get; set; }

        public virtual string Empresa { get; set; }

    }
}
