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
    
    public partial class Strength
    {
        public int id_Strength { get; set; }
        public string Strength_Description { get; set; }
        public Nullable<int> NbOfSets { get; set; }
        public Nullable<int> RepsPerSet { get; set; }
        public Nullable<int> WeightPerRep { get; set; }
        public Nullable<int> Calories_burned { get; set; }
    }
}
