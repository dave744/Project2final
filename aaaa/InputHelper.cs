using System;

namespace BookLibraryApp
{
    public static class InputHelper
    {
        public static string ReadText(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Enter something, don't just press enter.");

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static int ReadYear(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int year) && year > 0 && year <= DateTime.Now.Year + 1)
                    return year;

                Console.WriteLine("That doesn't look like a year, try again.");
            }
        }
    }
}
