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
    
    public partial class encuesta_usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public encuesta_usuarios()
        {
            this.encuesta_resultados = new HashSet<encuesta_resultados>();
        }
    
        public int usua_id { get; set; }
        public string usua_nombre { get; set; }
        public Nullable<int> usua_empresa { get; set; }
        public Nullable<System.DateTime> usua_f_aplica { get; set; }
        public string usua_tipo { get; set; }
        public string usua_estatus { get; set; }
        public string usua_n_usuario { get; set; }
        public string usua_p_usuario { get; set; }
        public string usua_u_alta { get; set; }
        public Nullable<System.DateTime> usua_f_alta { get; set; }
        public string usua_u_cancela { get; set; }
        public Nullable<System.DateTime> usua_f_cancela { get; set; }
        public Nullable<int> usua_genero { get; set; }
        public Nullable<int> usua_edad { get; set; }
        public Nullable<int> usua_edo_civil { get; set; }
        public Nullable<int> usua_sin_forma { get; set; }
        public Nullable<int> usua_primaria { get; set; }
        public Nullable<int> usua_secundaria { get; set; }
        public Nullable<int> usua_preparatoria { get; set; }
        public Nullable<int> usua_tecnico { get; set; }
        public Nullable<int> usua_licenciatura { get; set; }
        public Nullable<int> usua_maestria { get; set; }
        public Nullable<int> usua_doctorado { get; set; }
        public Nullable<int> usua_tipo_puesto { get; set; }
        public Nullable<int> usua_tipo_contratacion { get; set; }
        public Nullable<int> usua_tipo_personal { get; set; }
        public Nullable<int> usua_tipo_jornada { get; set; }
        public Nullable<int> usua_rotacion_turno { get; set; }
        public Nullable<int> usua_tiempo_puesto { get; set; }
        public Nullable<int> usua_exp_laboral { get; set; }
        public string usua_presento { get; set; }
        public Nullable<int> usua_departamento { get; set; }
        public Nullable<int> usua_centro_trabajo { get; set; }
        public Nullable<int> usua_periodo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encuesta_resultados> encuesta_resultados { get; set; }
    }
}
