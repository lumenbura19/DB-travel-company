//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace turism
{
    using System;
    using System.Collections.Generic;
    
    public partial class Marshrut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marshrut()
        {
            this.Putevka = new HashSet<Putevka>();
        }
    
        public int idMarsh { get; set; }
        public string city { get; set; }
        public string prim { get; set; }
        public int idOtel { get; set; }
        public Nullable<double> stoimPerelet { get; set; }
        public Nullable<double> stoimTransfer { get; set; }
        public int prodolgitSutok { get; set; }
        public Nullable<int> idUslug { get; set; }
    
        public virtual Otel Otel { get; set; }
        public virtual Usluga Usluga { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Putevka> Putevka { get; set; }
    }
}