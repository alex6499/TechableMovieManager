using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public static class RentalsTable
    {
        private static TechableDSTableAdapters.RentalsTableAdapter adapter;

        private static TechableDSTableAdapters.RentalsTableAdapter getNewAdapter()
        {
            return new TechableDSTableAdapters.RentalsTableAdapter();
        }

        public static void add(string upc, int customerId, string userName, DateTime dueDate)
        {
            adapter = getNewAdapter();
            adapter.Insert(upc, customerId, userName, dueDate, false);
            adapter.Dispose();
        }
        public static DataTable getNotReturned()
        {
            DataTable table;

            adapter = getNewAdapter();
            table = adapter.GetCurrentlyRented();
            adapter.Dispose();

            return table;
        }
        public static void returnMovie(string upc)
        {
            adapter = getNewAdapter();
            adapter.ReturnMovie(upc);
            adapter.Dispose();
        }
    }
}
