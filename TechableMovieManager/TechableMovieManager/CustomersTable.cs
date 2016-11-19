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
        private static TechableDSTableAdapters.CustomersTableAdapter adapter;

        private static TechableDSTableAdapters.CustomersTableAdapter getNewAdapter()
        {
            return new TechableDSTableAdapters.CustomersTableAdapter();
        }

        public static DataTable getAll()
        {
            TechableDS.CustomersDataTable table;

            adapter = getNewAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(string lName, string fName, string email, string address, string phone)
        {
            adapter = getNewAdapter();
            adapter.Insert(lName, fName, email, address, phone, false, 0);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int customerId)
        {
            adapter = getNewAdapter();
            adapter.UpdateDeleted(deleted, customerId);
            adapter.Dispose();
        }
    }
}
