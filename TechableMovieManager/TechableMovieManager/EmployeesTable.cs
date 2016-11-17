using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    class EmployeesTable
    {
        public static void add(string lName, string fName, bool isAdmin, string userName, string password)
        {
            TechableDSTableAdapters.EmployeesTableAdapter adapter = new TechableDSTableAdapters.EmployeesTableAdapter();
            adapter.Insert(fName, lName, isAdmin, userName, password, false);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int employeeId)
        {
            TechableDSTableAdapters.EmployeesTableAdapter adapter = new TechableDSTableAdapters.EmployeesTableAdapter();
            adapter.UpdateDeleted(deleted, employeeId);
            adapter.Dispose();
        }

        public static DataTable getAll()
        {
            TechableDS.EmployeesDataTable table;

            TechableDSTableAdapters.EmployeesTableAdapter adapter = new TechableDSTableAdapters.EmployeesTableAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static  Object[] getEmployee(string userName, string password)
        {
            TechableDS.EmployeesDataTable table;

            TechableDSTableAdapters.EmployeesTableAdapter adapter = new TechableDSTableAdapters.EmployeesTableAdapter();
            table = adapter.GetDataBy(userName, password);
            adapter.Dispose();
            
            if (table.Select().Length > 0)
            {
                return table.Select()[0].ItemArray;
            }
            else
            {
                return null;
            }
        }
    }
}
