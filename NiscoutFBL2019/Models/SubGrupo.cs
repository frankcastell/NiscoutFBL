//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NiscoutFBL2019.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubGrupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubGrupo()
        {
            this.Membresia_Juveniles = new HashSet<Membresia_Juvenil>();
            this.Eventos = new HashSet<Evento>();
            this.Membresia_Adultos = new HashSet<Membresia_Adulto>();
        }
    
        public int Id { get; set; }
        public string Cod_Subgrupo { get; set; }
        public string Nombre_Subgrupo { get; set; }
        public string Descripcion { get; set; }
        public int AsistenteId { get; set; }
        public int Tipo_GrupoId { get; set; }
        public int GrupoId { get; set; }
    
        public virtual Asistente Asistente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membresia_Juvenil> Membresia_Juveniles { get; set; }
        public virtual Tipo_Grupo Tipo_Grupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento> Eventos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membresia_Adulto> Membresia_Adultos { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
