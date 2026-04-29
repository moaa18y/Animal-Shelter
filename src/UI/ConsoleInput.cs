using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_Shelter.UI
{
    public class ConsoleInput
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            int value;

            while (true)
            {
                Console.Write("  " + prompt);
                string raw = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(raw, out value) && value >= min && value <= max)
                    return value;

                Console.WriteLine("Invalid number, try again.");
            }
        }

        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write("  " + prompt);
                string value = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
                Console.WriteLine("This field cannot be empty. Please try again.");
            }
        }


        public static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write("  " + prompt);
                string raw = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                if (raw == "y" || raw == "yes") return true;
                if (raw == "n" || raw == "no") return false;
                Console.WriteLine("Please enter y (yes) or n (no).");
            }
        }
    }
}
