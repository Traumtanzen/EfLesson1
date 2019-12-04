using EfLesson1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace EfLesson1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ManageStock();

        }

        static async Task ManageStock()
        {
            while (true)
            {
                Console.WriteLine("Do you want to add item?(y/n)");
                string answer = Console.ReadLine();
                if (answer != "y") break;
                Console.WriteLine("Select a shop to add item");
                using (var context = new ShopContext())
                {
                    foreach (var shop in context.Shops)
                    {
                        Console.WriteLine($"{shop.Id} - {shop.ShopName}");
                    }
                    var selectedShop = await context.Shops.Include(x=>x.Stock).FirstOrDefaultAsync(x=>x.Id == int.Parse(Console.ReadLine()));

                    var item = new ShopItem();
                    Console.WriteLine("enter brand");
                    item.Brand = Console.ReadLine();
                    Console.WriteLine("enter price");
                    item.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter size");
                    item.Size = int.Parse(Console.ReadLine());

                    selectedShop.Stock.Add(item);
                    context.SaveChanges();
                }


            }
        }
    }
}
