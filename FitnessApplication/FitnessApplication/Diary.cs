//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessApplication
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Diary
    {
        public int id_Diary { get; set; }
        public int id_Diary_Entry { get; set; }
        public Nullable<int> id_Account { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual DiaryEntry DiaryEntry { get; set; }
    }
}
