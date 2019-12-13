using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using EfLesson1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EfLesson1.Actions
{
    public class ManageSellers
    {
        ManagingOptions Management = new ManagingOptions();

        public async Task AddSeller()
        {
            using (var context = new ShopContext())
            {
                ManageShops shops = new ManageShops();
                Seller seller = new Seller();
                Console.WriteLine("Enter seller's name");
                seller.Name = Console.ReadLine();
                Console.WriteLine("Select a shop to add a seller");
                shops.ListOfShops();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Shops.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var shopToAdd = context.Shops.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        seller.Shop = shopToAdd;
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The seller is added. Do you want to add other sellers? (Y/N)");
                while (true)
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y") { await AddSeller(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageSellers(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }

        public async Task ShowSellers()
        {
            ListOfSellers();
            await Management.ManageSellers();
        }
        public void ListOfSellers()
        {
            Console.WriteLine("Here is the list of employeed sellers:");
            using (var context = new ShopContext())
            {
                foreach (var sellers in context.Sellers)
                {
                    Console.WriteLine($"{sellers.Id} - {sellers.Name}, {sellers.Shop}");
                }
            }
        }
        public async Task RemoveSeller()
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("You can remove the following sellers by entering their index:");
                ListOfSellers();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Sellers.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var sellerToRemove = context.Sellers.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        context.Sellers.Remove(sellerToRemove);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The seller is removed. Do you want to remove other sellers? (Y/N)");
                string answer = Console.ReadLine();
                while (true)
                {
                    if (answer.ToLower() == "y") { await RemoveSeller(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageSellers(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }


    }
}

