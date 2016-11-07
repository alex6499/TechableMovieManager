using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public class RentalsTable
    {
        DataSet1.RentalsDataTable table;
        DataSet1TableAdapters.RentalsTableAdapter adapter;
        public RentalsTable()
        {
            table = new DataSet1.RentalsDataTable();
            adapter = new DataSet1TableAdapters.RentalsTableAdapter();
        }

        public void add(int movieId, int customerId, int employeeId, string dueDate, decimal fine)
        {
            adapter.InsertSansId(movieId, customerId, employeeId, dueDate, fine);
        }
    }
}
