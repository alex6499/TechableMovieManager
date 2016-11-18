using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public static class CustomersTable
    {
        public static DataTable getAll()
        {
            TechableDS.CustomersDataTable table;

            TechableDSTableAdapters.CustomersTableAdapter adapter = new TechableDSTableAdapters.CustomersTableAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(string lName, string fName, string email, string address, string phone)
        {
            TechableDSTableAdapters.CustomersTableAdapter adapter = new TechableDSTableAdapters.CustomersTableAdapter();
            adapter.Insert(lName, fName, email, address, phone, false, 0);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int customerId)
        {
            TechableDSTableAdapters.CustomersTableAdapter adapter = new TechableDSTableAdapters.CustomersTableAdapter();
            adapter.UpdateDeleted(deleted, customerId);
            adapter.Dispose();
        }
    }
}
