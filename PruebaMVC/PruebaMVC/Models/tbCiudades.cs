//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbCiudades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCiudades()
        {
            this.tbEmpleados = new HashSet<tbEmpleados>();
            this.tbParticipantes = new HashSet<tbParticipantes>();
            this.tbEventos = new HashSet<tbEventos>();
        }
    
        public int ciu_Id { get; set; }
        public string ciu_descripcion { get; set; }
        public Nullable<int> dep_Id { get; set; }
        public Nullable<bool> ciu_Estado { get; set; }
        public Nullable<int> usu_UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> ciu_FechaCreacion { get; set; }
        public Nullable<int> usu_UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> ciu_FechaModificacion { get; set; }
    
        public virtual tbUsuaios tbUsuaios { get; set; }
        public virtual tbUsuaios tbUsuaios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbParticipantes> tbParticipantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEventos> tbEventos { get; set; }
        public virtual tbDepartamentos tbDepartamentos { get; set; }
    }
}
