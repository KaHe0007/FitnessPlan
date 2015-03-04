using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class TrainingService
    {
        public ObservableCollection<Training> Select()
        {
            var list = new ObservableCollection<Training>();
            var result = EntityManager.FitnessAppEntities.Training;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Training Insert(Training element)
        {
            EntityManager.FitnessAppEntities.Training.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Training element)
        {
            EntityManager.FitnessAppEntities.Training.Attach(element);
            EntityManager.FitnessAppEntities.Training.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
