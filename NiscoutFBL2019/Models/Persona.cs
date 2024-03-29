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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Tutorias = new HashSet<Tutoria>();
        }
    
        public int Id { get; set; }
        public string Cod_Persona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime Fecha_Nac { get; set; }
        public string E_Mail { get; set; }
        public string Cedula { get; set; }
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public string Num_Pasaporte { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int DepartamentoId { get; set; }
        public string Profesion { get; set; }
        public string Centro_Laboral { get; set; }
        public string Tipo_Sangre { get; set; }
    
        public virtual Departamento Departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tutoria> Tutorias { get; set; }
    }
}
