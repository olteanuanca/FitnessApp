
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
    
public partial class MyCardio
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public MyCardio()
    {

        this.Accounts_Cardio = new ObservableCollection<Accounts_Cardio>();

    }


    public int id_myCardio { get; set; }

    public string Cardio_Description { get; set; }

    public Nullable<int> Duration_min { get; set; }

    public Nullable<int> Calories_burned { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ObservableCollection<Accounts_Cardio> Accounts_Cardio { get; set; }

}

}
