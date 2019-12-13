using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using EfLesson1.Models;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;

namespace EfLesson1.Actions
{
    public class NewCustomers
    {
        Customing Customing = new Customing();
        Customer Customer = new Customer();

        public async Task NewCustomer()
        {
            Console.WriteLine("Hello! What's your name.");
            Customer.Name = Console.ReadLine();
            await WhereToGo();
        }
        public async Task WhereToGo()
        {
            Console.WriteLine($"Ok, {Customer.Name}, which shop do you want to go to?");
            ManageShops shops = new ManageShops();
            Order order = new Order();
            shops.ListOfShops();
            using (var context = new ShopContext())
            {
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Shops.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var selectedShop = context.Shops.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        foreach (var items in selectedShop.Stock)
                        {
                            Console.WriteLine("Ok! Here is the list of goods in this shop. Choose what to buy.");
                            Console.WriteLine($"{items.Id} - {items.Brand}, size: {items.Size}, price {items.Price}");
                        }
                        Int32.TryParse(Console.ReadLine(), out int selectedGoods);
                        if ((selectedShop.Stock.Count() <= (selectedGoods - 1)) && ((selectedGoods - 1) >= 0))
                        {
                            var orderIt = selectedShop.Stock.Where(i => i.Id == selectedGoods).FirstOrDefault();
                            order.Items.Add(orderIt);
                            order.OrderDate = DateTime.Today;
                            order.Shop = selectedShop;
                            context.SaveChanges();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                    Console.WriteLine("The item is bought. Do you want to buy other items? (Y/N)");
                    while (true)
                    {
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "y") { await WhereToGo(); break; }
                        else if (answer.ToLower() == "n") { await Customing.GoCustoming(); break; }
                        else { Console.WriteLine("Invalid input. Try again."); }
                    }
                }
            }

        }
    }
}
