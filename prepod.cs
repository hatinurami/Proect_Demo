//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proect_Demo
{
    using System;
    using System.Collections.Generic;
    
    public partial class prepod
    {
        public int id { get; set; }
        public Nullable<int> id_class { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public string fatherName { get; set; }
        public Nullable<int> id_pol { get; set; }
        public string spech { get; set; }
    
        public virtual class_tab class_tab { get; set; }
        public virtual pol_tab pol_tab { get; set; }
    }
}
