using System;
using System.Collections.Generic;
using System.Linq;

namespace Yazaka
{
    class YourClass
    {
        // Dictionary to store the prices of each item
        static Dictionary<string, double> itemPrices = new Dictionary<string, double>
        {
            { "Sake (Salmon)", 18.99 },
            { "Maguro (Tuna)", 19.99 },
            { "Ebi (Shrimp)", 17.99 },
            { "Hamachi (Yellowtail)", 19.99 },
            { "Unagi (Eel)", 17.99 }
        };

        // Dictionary to store the quantity of each item in the order
        static Dictionary<string, int> order = new Dictionary<string, int>();
        
        // Variable to track if a discount coupon has been applied
        static bool discountCouponApplied = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yazaka Sushi.");

            // Loop to keep the application running until the user decides to exit
            bool running = true;
            while (running)
            {
                // Display the main menu
                DisplayMenu();

                // Get user input for menu choice
                string? userInput = Console.ReadLine();
                Console.WriteLine("Your choice is: " + userInput);

                // Process the user's choice
                switch (userInput)
                {
                    case "1":
                        PlaceOrder();
                        break;
                    case "2":
                        ReviewOrder();
                        break;
                    case "3":
                        ModifyOrder();
                        break;
                    case "4":
                        AddDiscountCoupon();
                        break;
                    case "5":
                        Checkout();
                        running = false; // Exit the loop and end the application
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        // Method to display the main menu
        static void DisplayMenu()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Choose one of the options:");
            Console.WriteLine("1. Show menu and place an order.");
            Console.WriteLine("2. Review my order.");
            Console.WriteLine("3. Modify my order.");
            Console.WriteLine("4. Add a discount coupon.");
            Console.WriteLine("5. Pay and end the application.");
            Console.WriteLine("*********************************");
        }

        // Method to place an order
        static void PlaceOrder()
        {
            Console.WriteLine("Select an item to order:");
            Console.WriteLine("1. Sake (Salmon) - $18.99");
            Console.WriteLine("2. Maguro (Tuna) - $19.99");
            Console.WriteLine("3. Ebi (Shrimp) - $17.99");
            Console.WriteLine("4. Hamachi (Yellowtail) - $19.99");
            Console.WriteLine("5. Unagi (Eel) - $17.99");

            string? userInput = Console.ReadLine();

            string? item = GetMenuItem(userInput);
            if (item == null)
            {
                Console.WriteLine("Invalid item choice.");
                return;
            }

            Console.WriteLine($"Enter the quantity for {item}:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            // Add the item and its quantity to the order dictionary
            if (order.ContainsKey(item))
                order[item] += quantity;
            else
                order[item] = quantity;

            Console.WriteLine("Item added to order.");
        }

        // Method to review the order
        static void ReviewOrder()
        {
            if (order.Count == 0)
            {
                Console.WriteLine("Your order is empty.");
                return;
            }

            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key} - Quantity: {item.Value} - Subtotal: ${itemPrices[item.Key] * item.Value:F2}");
            }

            double subtotal = order.Sum(item => itemPrices[item.Key] * item.Value);
            double tax = subtotal * 0.13;

            // Apply discount if the discount coupon is applied
            double discount = 0.0;
            if (discountCouponApplied)
            {
                discount = subtotal * 0.20;
                Console.WriteLine($"Subtotal: ${subtotal:F2}");
                Console.WriteLine($"Discount: ${discount:F2}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${subtotal:F2}");
            }

            Console.WriteLine($"Tax (HST 13%): ${tax:F2}");

            double total = subtotal + tax - discount;
            Console.WriteLine($"Total: ${total:F2}");
        }

        // Method to modify the order
        static void ModifyOrder()
        {
            if (order.Count == 0)
            {
                Console.WriteLine("Your order is empty.");
                return;
            }

            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key} - Quantity: {item.Value} - Subtotal: ${itemPrices[item.Key] * item.Value:F2}");
            }

            Console.WriteLine("Enter the number of the item you want to modify:");
            Console.WriteLine("1. Sake (Salmon)");
            Console.WriteLine("2. Maguro (Tuna)");
            Console.WriteLine("3. Ebi (Shrimp)");
            Console.WriteLine("4. Hamachi (Yellowtail)");
            Console.WriteLine("5. Unagi (Eel)");

            string userInput = Console.ReadLine();

            string menuItem = GetMenuItem(userInput);
            if (menuItem == null)
            {
                Console.WriteLine("Invalid item choice.");
                return;
            }

            if (!order.ContainsKey(menuItem))
            {
                Console.WriteLine("This item is not in your order. Please try again.");
                return;
            }

            Console.WriteLine($"Current quantity of {menuItem}: {order[menuItem]}");
            Console.WriteLine("Enter the new quantity:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            // Update the quantity of the selected item
            order[menuItem] = quantity;
            Console.WriteLine("Order modified successfully.");
        }

        // Method to add a discount coupon
        static void AddDiscountCoupon()
        {
            Console.WriteLine("Enter discount coupon code: (for 20% enter: yazaka20)");
            string couponCode = Console.ReadLine();

            if (couponCode == "yazaka20")
            {
                discountCouponApplied = true;
                Console.WriteLine("Discount coupon applied: 20% off!");
            }
            else
            {
                Console.WriteLine("Invalid coupon code.");
            }
        }

        // Method to process the checkout and display the final total
        static void Checkout()
        {
            if (order.Count == 0)
            {
                Console.WriteLine("Your order is empty.");
                return;
            }

            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key} - Quantity: {item.Value} - Subtotal: ${itemPrices[item.Key] * item.Value:F2}");
            }

            double subtotal = order.Sum(item => itemPrices[item.Key] * item.Value);
            double tax = subtotal * 0.13;

            // Apply discount if the discount coupon is applied
            double discount = 0.0;
            if (discountCouponApplied)
            {
                discount = subtotal * 0.20;
            }

            double total = subtotal + tax - discount;

            Console.WriteLine($"Subtotal: ${subtotal:F2}");
            Console.WriteLine($"Tax (HST 13%): ${tax:F2}");

            // Print discount if applicable
            if (discount > 0)
            {
                Console.WriteLine($"Discount: ${discount:F2}");
            }
            else
            {
                Console.WriteLine("No discount applied.");
            }

            Console.WriteLine($"Total: ${total:F2}");
            Console.WriteLine("Have a nice day.");
        }

        // Method to convert user input into menu item strings
        static string? GetMenuItem(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    return "Sake (Salmon)";
                case "2":
                    return "Maguro (Tuna)";
                case "3":
                    return "Ebi (Shrimp)";
                case "4":
                    return "Hamachi (Yellowtail)";
                case "5":
                    return "Unagi (Eel)";
                default:
                    return null;
            }
        }
    }
}
