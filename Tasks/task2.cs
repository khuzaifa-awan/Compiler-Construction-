using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Inputs
        string firstName = "khuzaifa";
        string lastName = "awan";
        string registrationNumber = "020";
        string favoriteMovie = "The Last Kingdom";
        string favoriteFood = "Chinese Rice";

        // Generate password
        string password = GeneratePassword(firstName, lastName, registrationNumber, favoriteMovie, favoriteFood);
        Console.WriteLine($"Generated Password: {password}");
    }

    static string GeneratePassword(string firstName, string lastName, string regNumber, string movie, string food)
    {
        // Extract components
        string firstPart = firstName.Substring(0, 2).ToLower();
        string lastPart = lastName.Substring(0, 2).ToLower();
        string moviePart = movie.Substring(0, 2).ToLower();
        string foodPart = food.Substring(0, 2).ToLower();

        // Combine all parts
        string combined = firstPart + lastPart + regNumber + moviePart + foodPart;

        // Shuffle the combined string
        Random random = new Random();
        string shuffled = new string(combined.OrderBy(c => random.Next()).ToArray());

        // Ensure at least one uppercase letter and one special character
        char randomUpper = (char)random.Next('A', 'Z' + 1);
        char randomSpecial = "!@#$%^&*()_+-=[]{};':\",.<>/?".ToCharArray()[random.Next(0, 26)];

        // Insert random uppercase and special character into the shuffled string
        int insertIndex = random.Next(0, shuffled.Length);
        shuffled = shuffled.Insert(insertIndex, randomUpper.ToString());
        shuffled = shuffled.Insert(random.Next(0, shuffled.Length), randomSpecial.ToString());

        // Ensure the password is not longer than 12 characters
        if (shuffled.Length > 12)
        {
            shuffled = shuffled.Substring(0, 12);
        }

        return shuffled;
    }
}
