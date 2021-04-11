using System;
using System.Collections.Generic;

namespace POSTerminal
{
    public class Product
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }


        public List<Product> databaseList = new List<Product>();

        public void Menu()
        {
            var productList = Database.RetriveItems();

            Console.WriteLine("Welcome to CJR! Here is our menu:");

            foreach (var item in productList)
            {
                Console.WriteLine($"{item.MealNumber}: {item.Name}, {item.Description}, ${item.Price}");
                databaseList.Add(item);
            }
        }

        public List<Product> GetOrder(List<Product> databaseList)
        {

            var products = new List<Product>();
            var menuItems = new List<string>();
            var mealNumbers = new List<string>();
            bool isValid;
            string addToOrder;
            string order;
            string menuItem = string.Empty;
            string mealNumber = string.Empty;

            do
            {
                do
                {
                    Console.WriteLine("What would you like to order? ");
                    order = Console.ReadLine();

                } while (string.IsNullOrEmpty(order));

                foreach (var item in databaseList)
                {
                    menuItems.Add(item.Name);
                    var number = item.MealNumber.ToString();
                    mealNumbers.Add(number);
                }

                if (menuItems.Contains(order))
                {
                    menuItem = order;
                }
                else if (mealNumbers.Contains(order))
                {

                    mealNumber = order;

                }
                else if (!menuItems.Contains(order))
                {                    
                    do
                    {
                        Console.WriteLine("Please enter a new item:");
                        menuItem = Console.ReadLine();

                    } while (!mealNumbers.Contains(menuItem) && !menuItems.Contains(menuItem));
                }

                string output;
                do
                {
                    Console.WriteLine("How many would you like?");
                    output = Console.ReadLine();

                } while (string.IsNullOrEmpty(output));

                var quantity = decimal.TryParse(output, out decimal number1) ? number1 : default;

                foreach (var item in databaseList)
                {
                    if (item.Name == menuItem)
                    {
                        products.Add(new Product { Name = item.Name, Quantity = quantity, Price = item.Price });
                    }
                    else if (int.TryParse(mealNumber, out int numbers))
                    {
                        if(item.MealNumber == numbers)
                        {
                            products.Add(new Product { Name = item.Name, Quantity = quantity, Price = item.Price });
                        }                       
                    }
                }

                do
                {
                    Console.WriteLine("Would you like to add to your order? (y/n)");
                    addToOrder = Console.ReadLine();
                    isValid = addToOrder != "y" && addToOrder != "n";

                } while (isValid);

            } while (addToOrder.ToLower() == "y");

            return products;
        }
    }
}