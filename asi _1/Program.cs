using System;

namespace PetSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pet Creation
            Console.WriteLine("Hello ,Welcome to the Pet Simulator!");
            Console.Write("Choose a pet type (cat, dog, or horse): ");
            string petType = Console.ReadLine().ToLower();
            Console.Write("Give your pet a name: ");
            string petName = Console.ReadLine();
            Console.WriteLine($"Welcome, {petName} the {petType}!");

            // Pet Stats
            int hunger = 5;
            int happiness = 5;
            int health = 5;

            // Game Loop
            bool isPlaying = true;
            while (isPlaying)
            {
                // Display Pet Status
                Console.WriteLine($"\nPet Status:", $"\n Hunger ({hunger})" + $" \nHappiness ({happiness})" + $" \nHealth ({health})");

                // Check for Critical Stats
                if (hunger <= 2)
                    Console.WriteLine($"{petName} is overfed!");
                else if (hunger >= 8)
                    Console.WriteLine($"{petName} is very hungry!");

                if (happiness <= 2)
                    Console.WriteLine($"{petName} is very unhappy!");
                else if (happiness >= 8)
                    Console.WriteLine($"{petName} is overjoyed!");

                if (health <= 2)
                    Console.WriteLine($"{petName} is very sick!");
                else if (health >= 8)
                    Console.WriteLine($"{petName} is in excellent health!");

                // Display Action Menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Status");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                // Perform Action
                switch (choice)
                {
                    case 1: // Feed
                        if (hunger >= 8)
                            Console.WriteLine($"{petName} is too full to eat!");
                        else
                        {
                            hunger += 2;
                            health++;
                            Console.WriteLine($"{petName} ate some food. Hunger increased, health improved slightly.");
                        }
                        break;
                    case 2: // Play
                        if (hunger <= 2)
                            Console.WriteLine($"{petName} is too hungry to play!");
                        else
                        {
                            happiness += 2;
                            hunger--;
                            Console.WriteLine($"{petName} played and had fun! Happiness increased, hunger decreased slightly.");
                        }
                        break;
                    case 3: // Rest
                        health += 2;
                        happiness--;
                        Console.WriteLine($"{petName} took a nap. Health improved, happiness decreased slightly.");
                        break;
                    case 4: // Stats
                        Console.WriteLine($"Stats: \n Hunger: {hunger} \n Happiness {happiness} \n Health {health}");
                        break;
                    case 5: // Quit
                        isPlaying = false;
                        Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Time Passage
                hunger++;
                happiness--;

                // Check for Neglect
                if (hunger >= 10 || happiness <= 0)
                {
                    health--;
                    Console.WriteLine($"{petName}'s health deteriorated due to neglect.");
                }
            }
        }
    }
}