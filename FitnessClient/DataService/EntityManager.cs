namespace FitnessClient.DataService
{
    public class EntityManager
    {
        public static FitnessAppEntities FitnessAppEntities { get; set; }

        static EntityManager()
        {
            FitnessAppEntities = new FitnessAppEntities();
            FitnessAppEntities.Configuration.LazyLoadingEnabled = true;
        }
    }
}
