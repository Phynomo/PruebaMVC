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
    
    public partial class tbParticipantes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbParticipantes()
        {
            this.tbEventoDetalle = new HashSet<tbEventoDetalle>();
        }
    
        public int par_Id { get; set; }
        public string par_PrimerNombre { get; set; }
        public string par_SegundoNombre { get; set; }
        public string par_PrimerApellido { get; set; }
        public string par_SegundoApellido { get; set; }
        public string par_Sexo { get; set; }
        public System.DateTime par_FechaNacimiento { get; set; }
        public int estad_Id { get; set; }
        public int ciu_Id { get; set; }
        public string par_Direccion { get; set; }
        public string par_Telefono { get; set; }
        public Nullable<bool> par_Estado { get; set; }
        public Nullable<int> usu_UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> par_FechaCreacion { get; set; }
        public Nullable<int> usu_UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> par_FechaModificacion { get; set; }
    
        public virtual tbCiudades tbCiudades { get; set; }
        public virtual tbEstadosCiviles tbEstadosCiviles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEventoDetalle> tbEventoDetalle { get; set; }
        public virtual tbUsuaios tbUsuaios { get; set; }
        public virtual tbUsuaios tbUsuaios1 { get; set; }
    }
}
