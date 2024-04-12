using System;

namespace ST10320810_POE_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Recipe object
            Recipe recipe = new Recipe();
            // Prompt the user to enter recipe details
            recipe.EnterRecipeDetails();
            // Display the entered recipe
            recipe.DisplayRecipe();

            // Menu loop to allow user interaction
            bool continueLoop = true;
            while (continueLoop)
            {
                // Display menu options
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Scale Recipe");
                Console.WriteLine("2. Reset Quantities");
                Console.WriteLine("3. Clear Recipe");
                Console.WriteLine("4. Exit");

                // Prompt user for choice
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        // Scale the recipe
                        recipe.ScaleRecipe();
                        // Display the scaled recipe
                        recipe.DisplayRecipe();
                        break;
                    case "2":
                        // Reset ingredient quantities to original values
                        recipe.ResetQuantities();
                        // Display the recipe with original quantities
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        // Clear recipe data and prompt user to enter a new recipe
                        recipe.ClearRecipe();
                        recipe.EnterRecipeDetails();
                        // Display the new recipe
                        recipe.DisplayRecipe();
                        break;
                    case "4":
                        // Exit the program
                        continueLoop = false;
                        break;
                    default:
                        // Display error message for invalid input
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        // Fields to store recipe details
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Loop to enter details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                Console.Write($"Enter the quantity of {ingredients[i]}: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {ingredients[i]}: ");
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];
            // Loop to enter details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe()
        {
            Console.Write("\nEnter scaling factor (0.5, 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            // Multiply each ingredient quantity by the scaling factor
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // Assuming original quantities are stored elsewhere and can be retrieved
            // For simplicity, just resetting to 1 for demonstration
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 1;
            }
        }

        // Method to clear recipe data
        public void ClearRecipe()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
        }
    }
}