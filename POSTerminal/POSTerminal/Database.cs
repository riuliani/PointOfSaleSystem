using System.Collections.Generic;
using System.IO;

namespace POSTerminal
{
    static class Database
    {

        public static List<Product> RetriveItems()
        {
            List<Product> menu = new List<Product>();

            using (var reader = new StreamReader(@"C:\Users\riuliani\source\repos\Midterm_POS\POSTerminal\POSTerminal\ProductItem.txt"))

            {
                string item;
                do
                {
                    item = reader.ReadLine();

                    if (item == null)
                    {
                        break;
                    }

                    var output = item.Split(",");
                    menu.Add(new Product
                    {
                        MealNumber = int.TryParse(output[0], out int number1) ? number1 : default,
                        Name = output[1],
                        Category = output[2],
                        Description = output[3],
                        Price = decimal.TryParse(output[4], out decimal number) ? number : default
                    });

                } while (item != null);
            }

            return menu;
        }

        public static void AddItemToMenu(string item)
        {
            using (var writer = new StreamWriter(@"C:\Users\riuliani\source\repos\Midterm_POS\POSTerminal\POSTerminal\ProductItem.txt", append: true))
            {
                writer.WriteLine(item);
            }
        }
    }
}
