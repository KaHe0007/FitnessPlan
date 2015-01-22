using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class ThemaService
    {
        public ObservableCollection<Thema> Select()
        {
            var list = new ObservableCollection<Thema>();
            var result = EntityManager.FitnessAppEntities.Thema;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Thema Insert(Thema element)
        {
            EntityManager.FitnessAppEntities.Thema.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Thema element)
        {
            EntityManager.FitnessAppEntities.Thema.Attach(element);
            EntityManager.FitnessAppEntities.Thema.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
