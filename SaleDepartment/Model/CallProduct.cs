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
    
    public partial class CallProduct
    {
        public int id { get; set; }
        public int CallId { get; set; }
        public int ProductId { get; set; }
    
        public virtual Call Calls { get; set; }
        public virtual Product Products { get; set; }
    }
}