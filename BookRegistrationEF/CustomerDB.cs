using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
	static class CustomerDB
	{
		public static List<Customer> GetAllCustomers()
		{

			BookContext context = new BookContext();
			

			return context.Customer.ToList();
		}
		/// <summary>
		/// adds customer to DB
		/// </summary>
		/// <param name="c">the customer you are adding.</param>
		public static void Add(Customer c)
		{
			var context = new BookContext();

			context.Customer.Add(c);

			context.SaveChanges();
		}
	}
}
