//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat1.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Chat = new HashSet<Chat>();
            this.Chat1 = new HashSet<Chat>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public bool ISActive { get; set; }
        public string Login { get; set; }
        public string Passvord { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> idPhotoActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat1 { get; set; }
        public virtual ImageStatus ImageStatus { get; set; }
    }
}
