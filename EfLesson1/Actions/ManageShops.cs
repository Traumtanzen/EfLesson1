using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using EfLesson1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EfLesson1.Actions
{
    public class ManageShops
    {
        ManagingOptions Management = new ManagingOptions();

        public async Task AddShop()
        {
            using (var context = new ShopContext())
            {
                Shop shop = new Shop();
                ManageAddresses addresses = new ManageAddresses();
                Console.WriteLine("Please, select the name for the shop.");
                shop.ShopName = Console.ReadLine();
                Console.WriteLine("Please, select the address for the shop by index.");
                addresses.ListOfAddresses();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Addresses.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        shop.Address = context.Addresses.ElementAt(selectedIndex - 1);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                context.SaveChanges();
                Console.WriteLine("The shop is added. Do you want to add other shops? (Y/N)");
                while (true)
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y") { await AddShop(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageShops(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }
        public async Task ShowShops()
        {
            ListOfShops();
            await Management.ManageShops();
        }
        public void ListOfShops()
        {
            Console.WriteLine("Here is the list of existing shops:");
            using (var context = new ShopContext())
            {
                foreach (var shops in context.Shops)
                {
                    Console.WriteLine($"{shops.Id} - {shops.ShopName}: {shops.Address.City}, {shops.Address.Street}, {shops.Address.HouseNumber}");
                }
            }
        }

        public async Task RemoveShop()
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("You can remove the following shops by entering their index:");
                ListOfShops();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Shops.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var shopToRemove = context.Shops.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        context.Shops.Remove(shopToRemove);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The address is removed. Do you want to remove other addresses? (Y/N)");
                string answer = Console.ReadLine();
                while (true)
                {
                    if (answer.ToLower() == "y") { await RemoveShop(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageShops(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }
    }
}


