namespace FitnessClient.DataService
{
    public class FitnessDataService
    {
        public VerzeichnisService VerzeichnisService { get; set; }
        public UebungService UebungService { get; set; }
        public ThemaService ThemaService { get; set; }
        public TrainingsartService TrainingsartService { get; set; }
        public PlanService PlanService { get; set; }
        public ProgrammService ProgrammService { get; set; }
        public BenutzerService BenutzerService { get; set; }
        public TageService TageService { get; set; }

        private static FitnessDataService _instance;

        private FitnessDataService()
        {
            VerzeichnisService = new VerzeichnisService();
            UebungService = new UebungService();
            ThemaService = new ThemaService();
            TrainingsartService = new TrainingsartService();
            PlanService = new PlanService();
            ProgrammService = new ProgrammService();
            BenutzerService = new BenutzerService();
            TageService = new TageService();
        }

        public static FitnessDataService Instance
        {
            get { return _instance ?? (_instance = new FitnessDataService()); }
        }
    }
}