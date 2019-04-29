using System;
using System.Collections.Generic;

namespace Penelope
{
    public partial class Demografia
    {
        public long IdDemografia { get; set; }
        public int Numerohc { get; set; }
        public DateTime FecEstado { get; set; }
        public short? Educacion { get; set; }
        public short? EstadoCivil { get; set; }
        public short? EstadoLaboral { get; set; }
        public short? Apoyo { get; set; }
        public short? IpAr { get; set; }
        public byte? IpArRelacion { get; set; }
        public string IpCausa { get; set; }
        public string Profesion { get; set; }
        public short? ActividadLaboral { get; set; }
        public short? DescripcionTrabajo { get; set; }
        public byte? NecesitaAyuda { get; set; }
        public short? NecesitaAyudaTipo { get; set; }
        public short? Talla { get; set; }
        public decimal? Peso { get; set; }
        public byte? Tabaco { get; set; }
        public DateTime? TabacoFechaIni { get; set; }
        public DateTime? TabacoFechaFin { get; set; }
        public short? TabacoCantidad { get; set; }
    }
}
