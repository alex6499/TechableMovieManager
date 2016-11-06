using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    class EmployeesTable
    {

        DataSet1TableAdapters.EmployeesTableAdapter adapter;
        public EmployeesTable()
        {
            adapter = new DataSet1TableAdapters.EmployeesTableAdapter();
        }

        public void add(string lName, string fName, bool isAdmin, string userName, string password)
        {
            adapter.InsertSansId(fName, lName, isAdmin, userName, password);
        }

        public Object[] getEmployee(string userName, string password)
        {
            DataSet1.EmployeesDataTable table;
            
            table = adapter.GetEmployeeByCredential(userName, password);
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
