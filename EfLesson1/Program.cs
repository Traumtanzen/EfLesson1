using EfLesson1.Actions;
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
            Console.WriteLine("Welcome to ShoeShop. Are you a customer or a manager?\n1 - Customer\n2 - Manager");
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out int startChoice);
                if (startChoice == 1)
                {
                    Managing managing = new Managing();
                    await managing.ManagerPassword();
                }
                else if (startChoice == 2)
                {
                    //await Customing();
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again");
                }
            }
        }

    }
}
