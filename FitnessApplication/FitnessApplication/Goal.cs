
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
    
public partial class Goal
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Goal()
    {

        this.Accounts = new ObservableCollection<Account>();

    }


    public int id_Goals { get; set; }

    public int id_Goals_FitnessG { get; set; }

    public int id_Goals_WeightG { get; set; }

    public int id_Goals_Nutrition { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ObservableCollection<Account> Accounts { get; set; }

    public virtual FitnessGoal FitnessGoal { get; set; }

    public virtual WeightGoal WeightGoal { get; set; }

    public virtual NutritionGoal NutritionGoal { get; set; }

}

}
