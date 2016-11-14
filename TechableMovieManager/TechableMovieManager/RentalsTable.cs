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
            DataSet2TableAdapters.RentalsTableAdapter adapter = new DataSet2TableAdapters.RentalsTableAdapter();
            adapter.InsertSansId(movieId, customerId, employeeId, dueDate, fine, false);
            adapter.Dispose();
        }

        public static void returnMovie(int upc)
        {
            DataSet2TableAdapters.RentalsTableAdapter adapter = new DataSet2TableAdapters.RentalsTableAdapter();
            adapter.ReturnMovie(upc);
            adapter.Dispose();
        }
    }
}
