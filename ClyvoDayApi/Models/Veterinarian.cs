using System.Text.Json.Serialization;

namespace ClyvoDayApi.Models
{
    public class Veterinarian
    {
        public int VeterinarianId { get; private set; }
        public string FullName { get; private set; }
        public string Crmv {  get; private set; }
        public string Specialty { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        [JsonIgnore]
        public Clinic? Clinic { get; private set; }
        public int ClinicId { get; private set; }

        protected Veterinarian() { }

        public Veterinarian (string fullName, string crmv, string specialty, string email, string phoneNumber, int clinicId)
        {
            FullName = fullName;
            Crmv = crmv;
            Specialty = specialty;
            Email = email;
            PhoneNumber = phoneNumber;
            ClinicId = clinicId;
        }

        public void UpdateContact(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }


        public void UpdateSpecialty(string specialty)
        {
            Specialty = specialty;
        }

        
    }

}

