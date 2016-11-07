using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public class CustomersTable
    {
        DataSet1.CustomersDataTable table;
        DataSet1TableAdapters.CustomersTableAdapter adapter;
        public CustomersTable()
        {
            table = new DataSet1.CustomersDataTable();
            adapter = new DataSet1TableAdapters.CustomersTableAdapter();
        }

        public void add(string lName, string fName, string email, string address, string phone)
        {
            adapter.InsertSansId(lName, fName, email, address, phone, false);
        }
    }
}
