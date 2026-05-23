namespace ClyvoDayApi.Models
{
    public class Pet
    {
        public int PetId { get; private set; }
        public string Name { get; private set; } //nome
        public string Species { get; private set; } //especie
        public string Breed { get; private set; } //raça
        public string Gender { get; private set; } //genero
        public int Age { get; private set; } //idade
        public decimal Weight { get; private set; } //peso
        public DateTime BirthDate { get; private set; } //data de aniversário
        public Tutor? Tutor { get; private set; }
        public int TutorId {  get; private set; }

        protected Pet() { }

        public Pet (string name, string species, string breed, string gender, int age, decimal weight, DateTime birthDate, int tutorId)
        {
            Name = name;
            Species = species;
            Breed = breed;
            Gender = gender;
            Age = age;
            Weight = weight;
            BirthDate = birthDate;
            TutorId = tutorId;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight <= 0)
                throw new ArgumentException("O peso deve ser maior que zero.");

            Weight = newWeight;
        }

    }
}
