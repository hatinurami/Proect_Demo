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
    
    public partial class members
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public string fatherName { get; set; }
        public Nullable<System.DateTime> data_rogd { get; set; }
        public Nullable<int> id_pol { get; set; }
        public Nullable<int> id_class { get; set; }
        public Nullable<int> id_person { get; set; }
        public Nullable<int> grade01 { get; set; }
        public Nullable<int> grade02 { get; set; }
        public Nullable<int> grade03 { get; set; }
        public Nullable<int> id_studNow { get; set; }
    
        public virtual class_tab class_tab { get; set; }
        public virtual grade grade { get; set; }
        public virtual grade grade1 { get; set; }
        public virtual grade grade2 { get; set; }
        public virtual person person { get; set; }
        public virtual pol_tab pol_tab { get; set; }
        public virtual studnow_tab studnow_tab { get; set; }
    }
}
