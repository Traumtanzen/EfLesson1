using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfLesson1.Actions
{
    public class Managing
    {
        public async Task ManagerPassword()
        {
            Console.WriteLine("Enter manager password");
            while (true)
            {
                string managerPass = Console.ReadLine();
                if (managerPass == "qwerty")
                {
                    await GoManaging();
                }
                else
                {
                    Console.WriteLine("Invalid password. Try again");
                }
            }
        }

        public async Task GoManaging()
        {
            Console.WriteLine("What do you want to manage?\n1 - Addresses\n2 - Shops\n3 - Sellers\n4 - Items");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int managerChoice);
                if (managerChoice < 1 || managerChoice > 4)
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
                else
                {
                    ManagingOptions options = new ManagingOptions();
                    if (managerChoice == 1) { await options.ManageAddresses(); }
                    else if (managerChoice == 2) { await options.ManageShops(); }
                    else if (managerChoice == 3) { await options.ManageSellers(); }
                    else if (managerChoice == 4) { await options.ManageItems(); }
                }
            }
        }

    }
}
