using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfLesson1.Actions
{
    public class Customing
    {
        public async Task GoCustoming()
        {
            NewCustomers customer = new NewCustomers();
            await customer.NewCustomer();
        }
    }
}
