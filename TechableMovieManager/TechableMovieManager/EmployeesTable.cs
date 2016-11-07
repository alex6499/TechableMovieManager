using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    class EmployeesTable
    {
        public static void add(string lName, string fName, bool isAdmin, string userName, string password)
        {
            DataSet2TableAdapters.EmployeesTableAdapter adapter = new DataSet2TableAdapters.EmployeesTableAdapter();
            adapter.Insert(fName, lName, isAdmin, userName, password, false);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int employeeId)
        {
            DataSet2TableAdapters.EmployeesTableAdapter adapter = new DataSet2TableAdapters.EmployeesTableAdapter();
            adapter.UpdateDeleted(deleted, employeeId);
            adapter.Dispose();
        }

        public static  Object[] getEmployee(string userName, string password)
        {
            DataSet2.EmployeesDataTable table;

            DataSet2TableAdapters.EmployeesTableAdapter adapter = new DataSet2TableAdapters.EmployeesTableAdapter();
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
