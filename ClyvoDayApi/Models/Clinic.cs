namespace ClyvoDayApi.Models
{
    public class Clinic
    {
        public int ClinicId { get; private set; }
        public string TradeName { get; private set; }
        public string Cnpj {  get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public ICollection<Veterinarian> Veterinarians { get; private set; }


        protected Clinic() {

            Veterinarians = new List<Veterinarian> ();

        }

        public Clinic (string tradeName, string cnpj, string email, string phoneNumber, string address)
        {
            TradeName = tradeName;
            Cnpj = cnpj;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Veterinarians = new List<Veterinarian>();
        }


    }
}
