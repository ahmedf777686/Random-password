using System.Text;

namespace Random_password
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int Option = 0;

			while (true)
			{
				do
				{

					Console.WriteLine("Please select an option");
					Console.WriteLine("[1] Generate random numbers");
					Console.WriteLine("[2] Generate random string");
					Console.WriteLine("===================");
				} while (!int.TryParse(Console.ReadLine(), out Option));

				if (Option == 1)
					GenerateRandomNumbers();
				if (Option == 2)
					GenerateRandomString();
			}

		}


		private static void GenerateRandomNumbers()
		{
			int Min = 0;
			int Max = 0;
			do
			{
				Console.WriteLine("Enter minimum Numbers");


			} while (!int.TryParse(Console.ReadLine(), out Min));


			Console.WriteLine("Enter maximum number:");
			while (!int.TryParse(Console.ReadLine(), out Max) || Max <= Min)
			{
				if (Max <= Min)
				{
					Console.WriteLine("Maximum number must be greater than minimum number. Please enter a valid maximum number:");
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid integer for the maximum number:");
				}
			}


			var random = new Random();
			var result = random.Next(Min, Max);
			Console.WriteLine($"Random number between {Min} and {Max}: {result}");

		}

		private static void GenerateRandomString()
		{
			// Constants for character sets
			const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
			const string Numbers = "0123456789";
			const string Symbols = "!@#$%^&*()_+-=[]{}|;:'\",.<>?/`~";

			Console.WriteLine("How many characters do you need? ");

			// Get the number of characters needed
			int n;
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
			{
				Console.Write("Please enter a valid positive number: ");
			}

			// Function to get user input (yes/no)
			bool GetYesOrNo(string question)
			{
				Console.WriteLine(question);
				string response;
				do
				{
					response = Console.ReadLine().ToUpper();
					if (response == "YES" || response == "NO")
					{
						break;
					}
					Console.Write("Please answer with 'Yes' or 'No': ");
				} while (true);
				return response == "YES";
			}

			// Get user preferences
			bool includeCapitalLetters = GetYesOrNo("Do you need capital letters? (Yes / No)");
			bool includeSmallLetters = GetYesOrNo("Do you need small letters? (Yes / No)");
			bool includeNumbers = GetYesOrNo("Do you need numbers? (Yes / No)");
			bool includeSymbols = GetYesOrNo("Do you need symbols? (Yes / No)");

			// Build the character set based on user preferences
			var characterSet = new StringBuilder();
			if (includeCapitalLetters)
			{
				characterSet.Append(CapitalLetters);
			}
			if (includeSmallLetters)
			{
				characterSet.Append(SmallLetters);
			}
			if (includeNumbers)
			{
				characterSet.Append(Numbers);
			}
			if (includeSymbols)
			{
				characterSet.Append(Symbols);
			}

			// Ensure there is at least one type of character selected
			if (characterSet.Length == 0)
			{
				Console.WriteLine("No character types selected. Exiting.");
				return;
			}

			// Generate the random string
			var random = new Random();
			var result = new StringBuilder(n);
			for (int i = 0; i < n; i++)
			{
				int index = random.Next(characterSet.Length);
				result.Append(characterSet[index]);
			}

			// Output the random string
			Console.WriteLine("===========================");
			Console.WriteLine($"Random String: {result}");
		}
	}

}
