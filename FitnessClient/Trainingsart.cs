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
    
    public partial class Trainingsart
    {
        public Trainingsart()
        {
            this.Thema = new HashSet<Thema>();
        }
    
        public int TrainingsartId { get; set; }
        public string Art { get; set; }
    
        public virtual ICollection<Thema> Thema { get; set; }
    }
}
