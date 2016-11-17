using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public static class RentalsTable
    {
        public static void add(int movieId, int customerId, int employeeId, string dueDate, decimal fine)
        {
            TechableDSTableAdapters.RentalsTableAdapter adapter = new TechableDSTableAdapters.RentalsTableAdapter();
            adapter.Insert(movieId, customerId, employeeId, System.DateTime.Parse(dueDate), fine, false);
            adapter.Dispose();
        }

        public static void returnMovie(int upc)
        {
            TechableDSTableAdapters.RentalsTableAdapter adapter = new TechableDSTableAdapters.RentalsTableAdapter();
            adapter.ReturnMovie(upc);
            adapter.Dispose();
        }
    }
}
