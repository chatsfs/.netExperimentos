//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOCENTES.WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Docente
    {
        public int docenteID { get; set; }
        public string nombres { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public int tipodocumentoID { get; set; }
        public string documento { get; set; }
        public System.DateTime fechanacimiento { get; set; }
        public System.DateTime fechacontratacion { get; set; }
        public int gradoinstruccionID { get; set; }
        public int cursoID { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual GradoInstruccion GradoInstruccion { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
