using System;
using AnimalShelter.src.Shared.CustomException;
namespace AnimalShelter.Shared
{
    public static partial class Helpers
    {
        
        public static string ReadPassword()
        {
            Console.Write("Password: ");
            var password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }
            while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static string ReadOptionalString(string prompt)
        {
            Console.Write(prompt);
            var value = Console.ReadLine();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static int? ParseOptionalInt(string prompt)
        {
            var value = ReadOptionalString(prompt);
            return int.TryParse(value, out var parsed) ? parsed : null;
        }

        public static DateTime? ReadOptionalDateTime(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return DateTime.TryParse(input, out var result) ? result : null;
        }

        public static bool? ReadOptionalBool(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return input.Trim().ToLowerInvariant() switch
            {
                "y" or "yes" or "true" => true,
                "n" or "no" or "false" => false,
                _ => null
            };
        }

        
        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.WriteLine($"\n{prompt}:");
                int i = 1;
                foreach (var value in Enum.GetValues<TEnum>())
                    Console.WriteLine($"  {i++}. {value}");

                Console.Write("Enter number: ");
                var input = Console.ReadLine()?.Trim();

                
                if (int.TryParse(input, out var idx))
                {
                    var values = Enum.GetValues<TEnum>();
                    if (idx >= 1 && idx <= values.Length)
                        return values[idx - 1];
                }
                else if (Enum.TryParse<TEnum>(input, true, out var byName))
                    return byName;

                Console.WriteLine("Invalid value. Try again.");
            }
        }

        public static TEnum? ReadOptionalEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            Console.WriteLine($"\n{prompt} (press Enter to skip):");
            int i = 1;
            foreach (var value in Enum.GetValues<TEnum>())
                Console.WriteLine($"  {i++}. {value}");

            Console.Write("Enter number or press Enter to skip: ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (int.TryParse(input, out var idx))
            {
                var values = Enum.GetValues<TEnum>();
                if (idx >= 1 && idx <= values.Length)
                    return values[idx - 1];
            }
            else if (Enum.TryParse<TEnum>(input, true, out var byName))
                return byName;

            return null;
        }

        
        public static TEnum ReadEnumByIndex<TEnum>(string prompt) where TEnum : struct, Enum
            => ReadEnum<TEnum>(prompt);   

        public static TEnum? ReadOptionalEnumByIndex<TEnum>(string prompt) where TEnum : struct, Enum
            => ReadOptionalEnum<TEnum>(prompt);

        
        public static void TryExecute(Action action, string successMessage = null)
        {
            try
            {
                action();
                if (!string.IsNullOrWhiteSpace(successMessage))
                    Console.WriteLine($"\n{successMessage}");
            }
            catch (AppException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        public static int? ParseOptionalRoleId()
        {
            Console.WriteLine("\n  Role options:");
            Console.WriteLine("  1 = Admin");
            Console.WriteLine("  2 = Employee");
            Console.WriteLine("  3 = User");
            var roleInput = ReadOptionalString("New role (1/2/3, press Enter to keep): ");
            return int.TryParse(roleInput, out var parsed) ? parsed : null;
        }
    }
}