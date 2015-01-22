using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class VerzeichnisService
    {
        public ObservableCollection<Verzeichnis> Select()
        {
            var list = new ObservableCollection<Verzeichnis>();
            var result = EntityManager.FitnessAppEntities.Verzeichnis;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Verzeichnis Insert(Verzeichnis element)
        {
            EntityManager.FitnessAppEntities.Verzeichnis.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Verzeichnis element)
        {
            EntityManager.FitnessAppEntities.Verzeichnis.Attach(element);
            EntityManager.FitnessAppEntities.Verzeichnis.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
