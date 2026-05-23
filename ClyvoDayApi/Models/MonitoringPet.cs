namespace ClyvoDayApi.Models
{
    public class MonitoringPet
    {
        public int MonitoringPetId { get; private set; }
        public int PetId { get; private set; }
        public Pet? Pet { get; private set; }
        public string Mood { get; private set; }
        public string EnergyLevel { get; private set; }
        public string Food { get; private set; }
        public string SleepQuality { get; private set; }
        public string RecentActivities { get; private set; }
        public bool Medication { get; private set; }
        public string Observations { get; private set; }
        public DateTime MonitoringDate { get; private set; }


        protected MonitoringPet() { }

        public MonitoringPet (int petId, string mood, string energyLevel, string food, string sleepQuality, string recentActivities, bool medication, string observations)
        {
            PetId = petId;
            Mood = mood;
            EnergyLevel = energyLevel;
            Food = food;
            SleepQuality = sleepQuality;
            RecentActivities = recentActivities;
            Medication = medication;
            Observations = observations;
            MonitoringDate = DateTime.UtcNow;
        }
    }
}
