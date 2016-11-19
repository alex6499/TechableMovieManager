using System;
using System.Collections.Generic;
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

        public static void add(int upc, int customerId, string userName, DateTime dueDate)
        {
            adapter = getNewAdapter();
            adapter.Insert(upc, customerId, userName, dueDate, false);
            adapter.Dispose();
        }

        public static void returnMovie(int upc)
        {
            adapter = getNewAdapter();
            adapter.ReturnMovie(upc);
            adapter.Dispose();
        }
    }
}
