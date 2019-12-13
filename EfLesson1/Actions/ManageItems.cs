using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using EfLesson1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EfLesson1.Actions
{
    public class ManageItems
    {
        ManagingOptions Management = new ManagingOptions();

        public async Task AddItem()
        {
            using (var context = new ShopContext())
            {
                ManageShops shops = new ManageShops();
                ShopItem item = new ShopItem();
                Shop shop = new Shop();
                Console.WriteLine("Enter brand");
                item.Brand = Console.ReadLine();
                Console.WriteLine("Enter price");
                double.TryParse(Console.ReadLine(), out double setPrice);
                item.Price = setPrice;
                Console.WriteLine("Enter size");
                int.TryParse(Console.ReadLine(), out int setSize);
                item.Size = setSize;
                Console.WriteLine("Select a shop to add an item");
                shops.ListOfShops();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Shops.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var shopToAdd = context.Shops.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        shopToAdd.Stock.Add(item);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The item is added. Do you want to add other items? (Y/N)");
                while (true)
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y") { await AddItem(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageItems(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }
        public async Task ShowItems()
        {
            ListOfItems();
            await Management.ManageItems();
        }
        public void ListOfItems()
        {
            Console.WriteLine("Here is the list of existing items:");
            using (var context = new ShopContext())
            {
                foreach (var items in context.ShopItems)
                {
                    Console.WriteLine($"{items.Id} - {items.Brand}, {items.Size}");
                }
            }
        }
        public async Task RemoveItem()
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("You can remove the following items by entering their index:");
                ListOfItems();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.ShopItems.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var itemToRemove = context.ShopItems.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        context.ShopItems.Remove(itemToRemove);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The item is removed. Do you want to remove other items? (Y/N)");
                string answer = Console.ReadLine();
                while (true)
                {
                    if (answer.ToLower() == "y") { await RemoveItem(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageItems(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }
    }
}