//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programm
    {
        public int ProgrammId { get; set; }
        public Nullable<int> PlanId { get; set; }
        public Nullable<int> UebungId { get; set; }
    
        public virtual Uebung Uebung { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
