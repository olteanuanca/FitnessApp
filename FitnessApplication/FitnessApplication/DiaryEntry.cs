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
    
    public partial class DiaryEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaryEntry()
        {
            this.Diaries = new ObservableCollection<Diary>();
        }
    
        public int id_DiaryEntry { get; set; }
        public System.DateTime DiaryDate { get; set; }
        public int id_DEntry_DBreakfast { get; set; }
        public int id_DEntry_DSnack1 { get; set; }
        public int id_DEntry_DLunch { get; set; }
        public int id_DEntry_DSnack2 { get; set; }
        public int id_DEntry_DDinner { get; set; }
        public int id_DEntry_DCardio { get; set; }
        public int id_DEntry_DStrength { get; set; }
        public int id_DEntry_DWater { get; set; }
        public int id_DEntry_DNotes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Diary> Diaries { get; set; }
        public virtual DiaryBreakfast DiaryBreakfast { get; set; }
        public virtual DiaryCardio DiaryCardio { get; set; }
        public virtual DiaryDinner DiaryDinner { get; set; }
        public virtual DiarySnack1 DiarySnack1 { get; set; }
        public virtual DiaryLunch DiaryLunch { get; set; }
        public virtual DiarySnack2 DiarySnack2 { get; set; }
        public virtual DiaryStrength DiaryStrength { get; set; }
        public virtual DiaryWater DiaryWater { get; set; }
        public virtual DiaryNote DiaryNote { get; set; }
    }
}
