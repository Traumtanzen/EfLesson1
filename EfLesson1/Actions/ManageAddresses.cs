using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using EfLesson1.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EfLesson1.Actions
{
    public class ManageAddresses
    {
        ManagingOptions Management = new ManagingOptions();

        public async Task AddAddress()
        {
            using (var context = new ShopContext())
            {
                Address address = new Address();
                Console.WriteLine("Please, indicate a city.");
                address.City = Console.ReadLine();
                Console.WriteLine("Please, indicate a street.");
                address.Street = Console.ReadLine();
                Console.WriteLine("Please, indicate a building number.");
                address.HouseNumber = Console.ReadLine();
                context.SaveChanges();
                Console.WriteLine("The address is added. Do you want to add other addresses? (Y/N)");
                while (true)
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y") { await AddAddress(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageAddresses(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }

        public async Task ShowAddresses()
        {
            ListOfAddresses();
            await Management.ManageAddresses();
        }

        public void ListOfAddresses()
        {
            Console.WriteLine("Here is the list of existing addresses:");
            using (var context = new ShopContext())
            {
                foreach (var addresses in context.Addresses)
                {
                    Console.WriteLine($"{addresses.Id} - {addresses.City}, {addresses.Street}, {addresses.HouseNumber}");
                }
            }
        }

        public async Task RemoveAddress()
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("You can remove the following addresses by entering their index:");
                ListOfAddresses();
                while (true)
                {
                    Int32.TryParse(Console.ReadLine(), out int selectedIndex);
                    if ((context.Addresses.Count() <= (selectedIndex - 1)) && ((selectedIndex - 1) >= 0))
                    {
                        var addressToRemove = context.Addresses.Where(i => i.Id == selectedIndex).FirstOrDefault();
                        context.Addresses.Remove(addressToRemove);
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                Console.WriteLine("The address is removed. Do you want to remove other addresses? (Y/N)");
                while (true)
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y") { await RemoveAddress(); break; }
                    else if (answer.ToLower() == "n") { await Management.ManageAddresses(); break; }
                    else { Console.WriteLine("Invalid input. Try again."); }
                }
            }
        }
    }
}
