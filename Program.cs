using System;
using System.Collections.Generic;

namespace PizzaDeAmor
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Pizza De Amor!");

            string[] pizzaTypes = { "Cheese", "Pepperoni", "Veggies", "All-Meat", "Pizza Bianca" };
            string[] pizzaSizes = { "Regular", "Large" };
            decimal baseCost = 200.00M;
            decimal sizeCost = 40.00M;

            Console.WriteLine("\nAvailable Pizza Types: ");
            for (int i = 0; i < pizzaTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzaTypes[i]}");
            }

            Console.Write("Please select your choice of pizza type (enter the nummber): ");
            int pizzaTypeIndex = int.Parse(Console.ReadLine()) - 1;
            
            Console.WriteLine("\nAvailable Pizza Sizes:");
            for (int i = 0; i < pizzaSizes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzaSizes[i]}");
            }

            Console.Write("Please select the pizza size (enter the number): ");
            int pizzaSizeIndex = int.Parse(Console.ReadLine()) - 1;

            Pizza orderedPizza = new Pizza(pizzaTypes[pizzaTypeIndex], pizzaSizes[pizzaSizeIndex]);

            Console.Write("\nWould you like to add any toppings? (y/n): ");
            char addToppings = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (addToppings == 'y')
            {
                string[] availableToppings = { "Onion", "Mushroom", "Pepper", "Olive" };
                Console.WriteLine("\nAvailable Toppings: " + string.Join(", ", availableToppings));

                while (true)
                {
                    string topping = Console.ReadLine();
                    if (topping.ToLower() == "done")
                        break;

                        orderedPizza.Toppings.Add(topping);
                }
            }

            decimal totalCost = baseCost + (orderedPizza.Size.ToLower() == "large" ? sizeCost : 0) + orderedPizza.Toppings.Count * 25.0m;

            Console.WriteLine("\n\nOrder Summary:");
            Console.WriteLine($"Pizza Type: {orderedPizza.Type}");
            Console.WriteLine($"Pizza Size: {orderedPizza.Size}");
            Console.WriteLine("Toppings: " + (orderedPizza.Toppings.Count > 0 ? string.Join(", ", orderedPizza.Toppings) : "None"));
            Console.WriteLine($"Total Cost: {totalCost}");

            Console.WriteLine("\nThank you for ordering!");
        }
    }
}
class Pizza
{
    public string Type { get; set; }
    public string Size { get; set; }
    public List<string> Toppings { get; set; }

    public Pizza(string type, string size)
    {
        Type = type;
        Size = size;
        Toppings = new List<string>();
    }
}