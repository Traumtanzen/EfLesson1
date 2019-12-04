using EfLesson1.Models;
using System;
using System.Globalization;
using System.Threading;

namespace EfLesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            try
            {
                using (var context = new ShopContext())
                {

                    var address = new Address()
                    {
                        City = "Minsk",
                        Street = "Kalinovskogo",
                        HouseNumber = "80"
                    };

                    context.Addresses.Add(address);
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
