using System.Text.Json.Serialization;

namespace DemyAI.Models;
public partial class User : BaseViewModel {

    public string Uid { get; set; }

    public string Name { get; set; }

    public string Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    [JsonIgnore]
    public List<Roles> Roles => GetUserRoles();

    [ObservableProperty]
    public bool isInvited;

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    public string GenerateRandomNumberString() {
        Random random = new();
        const string chars = "0123456789"; // Digits 0-9
        char[] randomDigits = new char[8]; // Array to store 8 random digits

        for (int i = 0; i < 8; i++) {
            randomDigits[i] = chars[random.Next(chars.Length)];
        }

        string randomNumber = new(randomDigits);
        return randomNumber;
    }

    public List<Roles> GetUserRoles() {

        return [Helpers.Roles.Teacher, Helpers.Roles.Student];
    }
}
