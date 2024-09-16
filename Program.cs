namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Välkommen till Nummerspelet!");
            bool gameActive = true;
            while (gameActive)
            {
                PlayGame();
                Console.WriteLine("Vill du spela igen? (j/n)");

                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "j")
                {
                    gameActive = false;
                }
            }
            void PlayGame ()
            {
                int correctNumber;

                Console.WriteLine("Välj svårighetsgrad (1-3):");

                bool choiceIsNumber = int.TryParse(Console.ReadLine(), out int difficultyLevel);
                if (!choiceIsNumber)
                {
                    Console.WriteLine("Det där är inte ett giltigt heltal, försök igen.");
                    return;
                }

                switch (difficultyLevel)
                {
                    case 1:
                        Console.WriteLine("Du valde Lätt. (1-20)");
                        correctNumber = random.Next(1, 21);
                        break;
                    case 2:
                        Console.WriteLine("Du valde Medel. (1-40)");
                        correctNumber = random.Next(1, 41);
                        break;
                    case 3:
                        Console.WriteLine("Du valde Svår. (1-60)");
                        correctNumber = random.Next(1, 61);
                        break;
                    case 666:
                        Console.WriteLine("Du valde TOO EASY. (1-2)");
                        correctNumber = random.Next(1, 3);
                        break;
                    default:
                        Console.WriteLine("Du valde en ogiltig svårighetsgrad.");
                        return;
                }

                Console.WriteLine("Nu valde jag ett nummer. Kan du gissa vilket? Du får fem försök.");

                bool guessedCorrectly = false;

                for (int i = 0; i < 5 && !guessedCorrectly; i++)
                {
                    Console.Write($"Försök {i + 1}: ");

                    if (!int.TryParse(Console.ReadLine(), out int guess))
                    {
                        Console.WriteLine("Det där är inte ett giltigt heltal, försök igen.");
                        i--;
                        continue;

                    }

                    CheckGuess(guess, correctNumber);
                    guessedCorrectly = guess == correctNumber;
                }

                if (!guessedCorrectly)
                {
                    Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på fem försök! Numret var {correctNumber}");
                }
            }

            void CheckGuess(int guess, int correctNumber)
            {
                string[] correctResponses = {
                    "Wohoo! Du klarade det!",
                    "Rätt gissat! Bra jobbat!",
                    "Perfekt! Du hittade det rätta numret!"
                };

                string[] tooLowResponses = {
                    "Tyvärr, du gissade för lågt!",
                    "För lågt! Prova ett högre tal.",
                    "Inte rätt, men det är för lågt!"
                };

                string[] tooHighResponses = {
                    "Tyvärr, du gissade för högt!",
                    "För högt! Prova ett lägre tal.",
                    "Inte rätt, men det är för högt!"
                };

                if (guess == correctNumber)
                {
                    Console.WriteLine(correctResponses[random.Next(correctResponses.Length)]);
                }
                else if (guess - 1 == correctNumber || guess + 1 == correctNumber)
                {
                    Console.WriteLine("Det bränns!");
                }
                else if (guess < correctNumber)
                {
                    Console.WriteLine(tooLowResponses[random.Next(tooLowResponses.Length)]);
                }
                else
                {
                    Console.WriteLine(tooHighResponses[random.Next(tooHighResponses.Length)]);
                }
            }
        }
    }
}