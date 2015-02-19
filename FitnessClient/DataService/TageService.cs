using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class TageService
    {
        public ObservableCollection<Tage> Select()
        {
            var list = new ObservableCollection<Tage>();
            var result = EntityManager.FitnessAppEntities.Tage;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Tage Insert(Tage element)
        {
            EntityManager.FitnessAppEntities.Tage.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Tage element)
        {
            EntityManager.FitnessAppEntities.Tage.Attach(element);
            EntityManager.FitnessAppEntities.Tage.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
