using System;
using System.Collections.Generic;

namespace Penelope
{
    public partial class Consulta
    {
        public int Numerohc { get; set; }
        public DateTime FecConsulta { get; set; }
        public string CodAgenda { get; set; }
        public int? IdHorario { get; set; }
        public string CodPrestacion { get; set; }
        public string Coddestino { get; set; }
        public int? Codpers { get; set; }
        public byte PendienteSf { get; set; }
        public int? Artocentresis { get; set; }
        public int? Infiltración { get; set; }
        public decimal ConsultaId { get; set; }
        public string Tipo { get; set; }
        public string Destino { get; set; }
        public string Seguimiento { get; set; }
        public byte? EstadoAr { get; set; }
    }
}
