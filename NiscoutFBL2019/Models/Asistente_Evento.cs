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
    
    public partial class Asistente_Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asistente_Evento()
        {
            this.Detalle_Evento_Patros = new HashSet<Detalle_Evento_Patro>();
        }
    
        public int Id { get; set; }
        public System.TimeSpan Hora_Llegada { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Evento_Patro> Detalle_Evento_Patros { get; set; }
    }
}