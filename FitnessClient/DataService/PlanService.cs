using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class PlanService
    {
        public ObservableCollection<Plan> Select()
        {
            var list = new ObservableCollection<Plan>();
            var result = EntityManager.FitnessAppEntities.Plan;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public Plan Insert(Plan element)
        {
            EntityManager.FitnessAppEntities.Plan.Add(element);
            EntityManager.FitnessAppEntities.SaveChanges();
            return element;
        }

        public void Update()
        {
            EntityManager.FitnessAppEntities.SaveChanges();
        }

        public int Delete(Plan element)
        {
            EntityManager.FitnessAppEntities.Plan.Attach(element);
            EntityManager.FitnessAppEntities.Plan.Remove(element);
            return EntityManager.FitnessAppEntities.SaveChanges();
        }
    }
}
