namespace Simple_Turn_Based_Game;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to the Simple Turn-Based Game ===");
        Console.Write("Enter a name for your fighter: ");
        string playerName = GetValidString();

        Fighter player = new Fighter(playerName);
        Console.WriteLine($"{player.Name} is ready!");

        Fighter opponent = new Fighter("Monster");
        Console.WriteLine($"{player.Name} wander into an old dungeon and encountered a {opponent.Name}");

        int turnCount = 1;
        bool exit = false;
        while (!exit)
        {
            // Player's turns
            Console.WriteLine("\nWhat do you want to do?\n1. Attack\n2. Heal\n3. Escape");
            TurnStart:
            Console.Write("Enter your choice (1-3): ");

            string choice = GetValidString();
            switch (choice)
            {
                case "1":
                    player.Attack(opponent);
                    Console.WriteLine($"{player.Name} attacked the {opponent.Name} for {player.AttackPower} damage");
                    break;

                case "2":
                    player.Heal(out int healAmount);
                    Console.WriteLine($"{player.Name} has healed for {healAmount} HP points");
                    break;

                case "3":
                    Console.WriteLine($"{player.Name} escaped the {opponent.Name}!");
                    exit = true;
                    goto TurnEnd;

                default:
                    Console.WriteLine("Invalid input! Input must be between 1 and 3");
                    goto TurnStart;
            }

            if (opponent.IsDead)
            {
                Console.WriteLine($"{player.Name} has killed the {opponent.Name}!");
                Console.WriteLine($"\nCongratulations you managed to defeat the {opponent.Name} in {turnCount} turns");
                exit = true;
                goto TurnEnd;
            }

            // Opponent's turns
            opponent.Attack(player);
            Console.WriteLine($"{opponent.Name} attacked {player.Name} for {opponent.AttackPower} damage");

            if (player.IsDead)
            {
                Console.WriteLine($"{opponent.Name} has killed {player.Name}!");
                Console.WriteLine($"\nYou have played for {turnCount} turns");
                exit = true;
                goto TurnEnd;
            }

            Console.WriteLine($"\nGame status:\n{player.Name} health: {player.Health}/{player.MaxHealth}\n{opponent.Name} health: {opponent.Health}/{opponent.MaxHealth}");
            TurnEnd:
            turnCount++;
        }

        Console.WriteLine("\n=== Thank you for playing Simple Turn-Based Game! ===");
    }

    private static string GetValidString(string warning = "", string prompt = "")
    {
        string? result = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(result))
        {
            if (!string.IsNullOrWhiteSpace(warning))
            {
                Console.WriteLine(warning);
            }
            else
            {
                Console.WriteLine("Invalid input! Input cannot be empty!");
            }

            if (!string.IsNullOrWhiteSpace(prompt))
            {
                Console.Write(prompt);
            }
            else
            {
                Console.Write("Please enter a valid input: ");
            }

            result = Console.ReadLine();
        }

        return result;
    }
}
