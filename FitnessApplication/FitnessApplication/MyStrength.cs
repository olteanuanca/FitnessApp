
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
    
public partial class MyStrength
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public MyStrength()
    {

        this.Accounts_Strength = new ObservableCollection<Accounts_Strength>();

    }


    public int id_myStrength { get; set; }

    public string MyStrength_Description { get; set; }

    public Nullable<int> NbOfSets { get; set; }

    public Nullable<int> RepsPerSet { get; set; }

    public Nullable<int> WeightPerRep { get; set; }

    public Nullable<int> Calories_burned { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ObservableCollection<Accounts_Strength> Accounts_Strength { get; set; }

}

}
