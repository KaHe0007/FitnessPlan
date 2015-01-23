using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class ProgrammService
    {
        public ObservableCollection<Programm> Select()
        {
            var list = new ObservableCollection<Programm>();
            var result = EntityManager.FitnessAppEntities.Programm;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Programm Insert(Programm element)
        {
            EntityManager.FitnessAppEntities.Programm.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Programm element)
        {
            EntityManager.FitnessAppEntities.Programm.Attach(element);
            EntityManager.FitnessAppEntities.Programm.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
