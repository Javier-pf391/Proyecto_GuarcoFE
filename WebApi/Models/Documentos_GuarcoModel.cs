namespace WebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Documentos_GuarcoModel
    {
        [Display(Name = "ID DOCUMENTO")]
        public int id_documento { get; set; }

        [Display(Name = "CÓDIGO")]
        public string codigo { get; set; }

        [Display(Name = "NOMBRE")]
        public string nombre { get; set; }

        [Display(Name = "TIPO")]
        public string tipo { get; set; }

        [Display(Name = "NOMBRE ÁREA")]
        public string nombre_area { get; set; }

        [Display(Name = "DOCUMENTO")]
        public string documento { get; set; }

        [Display(Name = "ESTADO")]
        public string estado { get; set; }

        [Display(Name = "FECHA HORA INICIO")]
        public DateTime? Fecha_inicio { get; set; }

        [Display(Name = "FECHA HORA FINALIZACIÓN")]
        public DateTime? Fecha_finalizacion { get; set; }

        [Display(Name = "FECHA HORA REVISIÓN INICIO")]
        public DateTime? Fecha_revision_inicio { get; set; }

        [Display(Name = "FECHA HORA REVISIÓN FINALIZACIÓN")]
        public DateTime? Fecha_revision_finalizacion { get; set; }

        [Display(Name = "FECHA HORA APROBACIÓN")]
        public DateTime? Fecha_aprobacion { get; set; }

        public Documentos_GuarcoModel()
        {
            id_documento = 0;
            codigo = string.Empty;
            nombre = string.Empty;
            tipo = string.Empty;
            documento = string.Empty;
            nombre_area = string.Empty;
            estado = string.Empty;
            Fecha_inicio = null;
            Fecha_finalizacion = null;
            Fecha_revision_inicio = null;
            Fecha_revision_finalizacion = null;
            Fecha_aprobacion = null;
        }
    }

}
