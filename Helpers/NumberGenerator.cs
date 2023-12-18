namespace DemyAI.Helpers;

public class NumberGenerator {

    public static string GenerateRandomNumberString(int numberOfDigits) {
        Random random = new();
        const string chars = "0123456789"; // Digits 0-9
        char[] randomDigits = new char[numberOfDigits]; // Array to store 8 random digits

        int length = randomDigits.Length;

        for(int i = 0; i < length; ++i) {
            randomDigits[i] = chars[random.Next(chars.Length)];
        }

        string randomNumber = new(randomDigits);
        return randomNumber;
    }

}
