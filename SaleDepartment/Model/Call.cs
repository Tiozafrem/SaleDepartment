//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaleDepartment.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Call
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Call()
        {
            this.IsActual = true;
            this.CallProducts = new HashSet<CallProduct>();
        }
    
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int StatusCallId { get; set; }
        public System.DateTime DateTimeCall { get; set; }
        public Nullable<int> Duration { get; set; }
        public bool IsActual { get; set; }
        public string AddresDelivery { get; set; }
        public Nullable<System.DateTime> DateTimeDelivery { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CallProduct> CallProducts { get; set; }
        public virtual Client Clients { get; set; }
        public virtual StatusCall StatusCalls { get; set; }
        public virtual User Users { get; set; }
    }
}
