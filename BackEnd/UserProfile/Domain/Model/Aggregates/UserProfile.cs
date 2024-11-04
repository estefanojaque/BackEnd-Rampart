using System.Text.Json;
namespace BackEnd.UserProfile

{
    public class ProfileData
    {
        public int Id { get; set; }
        public string Photo { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public DateTime BirthDate { get; set; } 
        public string Address { get; set; } = string.Empty; 
        public string PaymentMethod { get; set; } = string.Empty; 
        public string CardNumber { get; set; } = string.Empty; 
        public string YapeNumber { get; set; } = string.Empty; 
        public bool CashPayment { get; set; }

        // Almacena las preferencias como un JSON en la base de datos
        public string PreferencesJson { get; set; } = string.Empty;

        // Propiedad para acceder a las preferencias como lista de strings
        public List<string> Preferences 
        { 
            get => string.IsNullOrEmpty(PreferencesJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(PreferencesJson);
            set => PreferencesJson = JsonSerializer.Serialize(value);
        }

        protected ProfileData() { }

        public ProfileData(CreateUserProfileCommand command)
        {
            Photo = command.Photo;
            Name = command.Name;
            Email = command.Email;
            BirthDate = command.BirthDate;
            Address = command.Address;
            PaymentMethod = command.PaymentMethod;
            CardNumber = command.CardNumber;
            YapeNumber = command.YapeNumber;
            CashPayment = command.CashPayment;
            Preferences = command.Preferences; // Aquí se espera que command.Preferences sea una lista de strings
        }
    }
}