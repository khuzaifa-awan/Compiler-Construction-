using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string regexPattern = @"^(?=.*SP)(?=.*[A-Z])(?=.*[!@#$%^&*()_+]{2})(?=.*[khuzafi]{4}).{1,12}$";
        Regex regex = new Regex(regexPattern);

        // Test cases
        string[] testCases = {
            "SP!@khu", // Valid
            "SP@#Khuz", // Valid
            "SP#khuza", // Invalid (more than 12 characters)
            "sp!@khu", // Invalid (no uppercase)
            "SP!khu", // Invalid (only one special character)
            "SP!@xyz" // Invalid (does not contain 4 letters from "khuzaifa")
        };

        foreach (var testCase in testCases)
        {
            bool isValid = regex.IsMatch(testCase);
            Console.WriteLine($"\"{testCase}\" is {(isValid ? "valid" : "invalid")}");
        }
    }
}
