//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atestados.Datos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Atestado = new HashSet<Atestado>();
            this.AtestadoXPersona = new HashSet<AtestadoXPersona>();
            this.EvaluaciónXAtestado = new HashSet<EvaluaciónXAtestado>();
        }
    
        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public int CategoriaActual { get; set; }
        public int TipoUsuario { get; set; }
        public Nullable<int> Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atestado> Atestado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtestadoXPersona> AtestadoXPersona { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluaciónXAtestado> EvaluaciónXAtestado { get; set; }
        public virtual TipoCategoria TipoCategoria { get; set; }
        public virtual TipoUsuario TipoUsuario1 { get; set; }
    }
}
