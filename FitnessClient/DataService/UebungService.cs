using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class UebungService
    {
        public ObservableCollection<Uebung> Select()
        {
            var list = new ObservableCollection<Uebung>();
            var result = EntityManager.FitnessAppEntities.Uebung;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Uebung Insert(Uebung element)
        {
            EntityManager.FitnessAppEntities.Uebung.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Uebung element)
        {
            EntityManager.FitnessAppEntities.Uebung.Attach(element);
            EntityManager.FitnessAppEntities.Uebung.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
