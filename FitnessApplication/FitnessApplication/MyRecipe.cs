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
    
    public partial class MyRecipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyRecipe()
        {
            this.Accounts_Recipes = new ObservableCollection<Accounts_Recipes>();
        }
    
        public int id_myRecipe { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<double> Servings { get; set; }
        public string Reciepe_Description { get; set; }
        public Nullable<double> Calories { get; set; }
        public Nullable<double> Carbs { get; set; }
        public Nullable<double> Protein { get; set; }
        public Nullable<double> Fat { get; set; }
        public Nullable<double> Cholesterol { get; set; }
        public Nullable<double> Sodium { get; set; }
        public Nullable<double> Potassium { get; set; }
        public Nullable<double> Fiber { get; set; }
        public Nullable<double> Sugars { get; set; }
        public Nullable<double> VitA { get; set; }
        public Nullable<double> VitC { get; set; }
        public Nullable<double> Calcium { get; set; }
        public Nullable<double> Iron { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Accounts_Recipes> Accounts_Recipes { get; set; }
    }
}
