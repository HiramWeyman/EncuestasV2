//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestasV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class encuesta_encuesta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public encuesta_encuesta()
        {
            this.encuesta_det_encuesta = new HashSet<encuesta_det_encuesta>();
            this.encuesta_resultados = new HashSet<encuesta_resultados>();
        }
    
        public int encu_id { get; set; }
        public string encu_descrip { get; set; }
        public string encu_status { get; set; }
        public string encu_u_alta { get; set; }
        public Nullable<System.DateTime> encu_f_alta { get; set; }
        public string encu_u_cancela { get; set; }
        public Nullable<System.DateTime> encu_f_cancela { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encuesta_det_encuesta> encuesta_det_encuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encuesta_resultados> encuesta_resultados { get; set; }
    }
}
