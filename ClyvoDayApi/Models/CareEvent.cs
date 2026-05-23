namespace ClyvoDayApi.Models
{
    public class CareEvent
    {
        public int CareEventId { get; private set; }
        public int PetId { get; private set; }
        public Pet? Pet { get; private set; }
        public string TypeEvent { get; private set; }
        public string Description { get; private set; }
        public DateTime EventDate { get; private set; }
        public bool EventCompleted { get; private set; }
        public string Observations { get; private set; }


        protected CareEvent() { }

        public CareEvent (int petId, string typeEvent, string description, DateTime eventDate, bool eventCompleted, string observations)
        {
            PetId = petId;
            TypeEvent = typeEvent;
            Description = description;
            EventDate = eventDate;
            EventCompleted = eventCompleted;
            Observations = observations;
        }
    }


}
