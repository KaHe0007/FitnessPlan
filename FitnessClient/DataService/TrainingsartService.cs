using System.Collections.ObjectModel;

namespace FitnessClient.DataService
{
    public class TrainingsartService
    {
        public ObservableCollection<Trainingsart> Select()
        {
            var list = new ObservableCollection<Trainingsart>();
            var result = EntityManager.FitnessAppEntities.Trainingsart;
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
