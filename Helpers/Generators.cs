namespace DemyAI.Helpers;

public static class Generators {

    public static string GenerateRandomDemyId(int numberOfDigits) {
        Random random = new();
        const string chars = "0123456789"; // Digits 0-9
        char[] randomDigits = new char[numberOfDigits]; // Array to store 8 random digits

        int length = randomDigits.Length;

        for (int i = 0; i < length; ++i) {
            randomDigits[i] = chars[random.Next(chars.Length)];
        }

        string randomNumber = new(randomDigits);

        return randomNumber;
    }

    public static string? GenerateRandomName(int numberOfLetters) {

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        StringBuilder stringBuilder = new(numberOfLetters);
        Random random = new();

        for (int i = 0; i < numberOfLetters; ++i) {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }
}
