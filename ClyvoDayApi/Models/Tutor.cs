namespace ClyvoDayApi.Models
{
    public class Tutor
    {
        public int TutorId { get; private set; }
        public string FullName { get; private set; }
        public string Cpf {  get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public int ScoreEngagement { get; private set; }
        public ICollection<Pet> Pets { get; private set; }
        


        protected Tutor () {

            Pets = new List<Pet> ();

        }

        public Tutor (string fullName, string cpf, string email, string password, string phoneNumber)
        {
            FullName= fullName;
            Cpf = cpf;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            ScoreEngagement = 0;
            Pets = new List<Pet>();
        }

        public void UpdateScore(int points)
        {
            ScoreEngagement += points;
        }

        public void UpdateContact(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
