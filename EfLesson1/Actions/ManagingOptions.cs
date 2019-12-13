using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfLesson1.Actions
{
    public class ManagingOptions
    {
        public async Task ManageAddresses()
        {
            Console.WriteLine("What do you want to do?\n1 - Show existing addresses\n2 - Add address\n3 - Remove addresses");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int managerChoice);
                if (managerChoice < 1 || managerChoice > 3)
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
                else
                {
                    ManageAddresses addreses = new ManageAddresses();
                    if (managerChoice == 1) { await addreses.ShowAddresses(); }
                    else if (managerChoice == 2) { await addreses.AddAddress(); }
                    else if (managerChoice == 3) { await addreses.RemoveAddress(); }
                }
            }
        }
        public async Task ManageShops()
        {
            Console.WriteLine("What do you want to do?\n1 - Show existing shops\n2 - Add shops\n3 - Remove shops");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int managerChoice);
                if (managerChoice < 1 || managerChoice > 3)
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
                else
                {
                    ManageShops shops = new ManageShops();
                    if (managerChoice == 1) { await shops.ShowShops(); }
                    else if (managerChoice == 2) { await shops.AddShop(); }
                    else if (managerChoice == 3) { await shops.RemoveShop(); }
                }
            }
        }
        public async Task ManageSellers()
        {
            Console.WriteLine("What do you want to do?\n1 - Show employeed sellers\n2 - Add sellers\n3 - Remove sellers");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int managerChoice);
                if (managerChoice < 1 || managerChoice > 3)
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
                else
                {
                    ManageSellers sellers = new ManageSellers();
                    if (managerChoice == 1) { await sellers.ShowSellers(); }
                    else if (managerChoice == 2) { await sellers.AddSeller(); }
                    else if (managerChoice == 3) { await sellers.RemoveSeller(); }
                }
            }
        }
        public async Task ManageItems()
        {
            Console.WriteLine("What do you want to do?\n1 - Show existing items\n2 - Add items\n3 - Remove items");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int managerChoice);
                if (managerChoice < 1 || managerChoice > 3)
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
                else
                {
                    ManageItems items = new ManageItems();
                    if (managerChoice == 1) { await items.ShowItems(); }
                    else if (managerChoice == 2) { await items.AddItem(); }
                    else if (managerChoice == 3) { await items.RemoveItem(); }
                }
            }
        }
    }
}
