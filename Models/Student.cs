namespace DemyAI.Models;
public class Student {

    public string Id { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    // Method to check if an email is valid
    public bool IsEmailValid(string email) {

        if (string.IsNullOrWhiteSpace(email))
            return false;

        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        } catch {
            return false;
        }
    }

    // Method to check if a password meets specific criteria
    public bool IsPasswordValid(string password) {

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            return false;

        // Check if the password contains at least one uppercase letter
        bool hasUppercase = password.Any(c => char.IsUpper(c));
        return hasUppercase;
    }

    public void SetPassword(string password) {

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password) {

        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);

    }

    public string GenerateRandomNumberString() {
        Random random = new Random();
        const string chars = "0123456789"; // Digits 0-9
        char[] randomDigits = new char[8]; // Array to store 8 random digits

        for (int i = 0; i < 8; i++) {
            randomDigits[i] = chars[random.Next(chars.Length)];
        }

        string randomNumber = new(randomDigits);
        return randomNumber;
    }
}
