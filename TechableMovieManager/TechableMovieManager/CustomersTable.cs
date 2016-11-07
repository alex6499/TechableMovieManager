﻿using System;
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
            DataSet2.CustomersDataTable table;

            DataSet2TableAdapters.CustomersTableAdapter adapter = new DataSet2TableAdapters.CustomersTableAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(string lName, string fName, string email, string address, string phone)
        {
            DataSet1TableAdapters.CustomersTableAdapter adapter = new DataSet1TableAdapters.CustomersTableAdapter();
            adapter.InsertSansId(lName, fName, email, address, phone, false);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int customerId)
        {
            DataSet1TableAdapters.CustomersTableAdapter adapter = new DataSet1TableAdapters.CustomersTableAdapter();
            adapter.UpdateDeleted(deleted, customerId);
            adapter.Dispose();
        }
    }
}
