using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class BenutzerService
    {
        public ObservableCollection<Benutzer> Select()
        {
            var list = new ObservableCollection<Benutzer>();
            var result = EntityManager.FitnessAppEntities.Benutzer;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Benutzer Insert(Benutzer element)
        {
            EntityManager.FitnessAppEntities.Benutzer.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Benutzer element)
        {
            EntityManager.FitnessAppEntities.Benutzer.Attach(element);
            EntityManager.FitnessAppEntities.Benutzer.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
