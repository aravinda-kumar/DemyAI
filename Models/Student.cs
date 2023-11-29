namespace DemyAI.Models;
public class Student {

    public string Id { get; set; }

    public string Email { get; set; }

    private string passwordHash; // Store hashed password

    public string Password {

        // Get: Return hashed password
        get => passwordHash;

        // Set: Hash the provided password and store the hash
        set {
            // Hash the password before setting it
            passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
        }
    }

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    public static string GenerateRandomNumberString() {
        Random random = new();
        const string chars = "0123456789"; // Digits 0-9
        char[] randomDigits = new char[8]; // Array to store 8 random digits

        for (int i = 0; i < 8; i++) {
            randomDigits[i] = chars[random.Next(chars.Length)];
        }

        string randomNumber = new(randomDigits);
        return randomNumber;
    }
}
