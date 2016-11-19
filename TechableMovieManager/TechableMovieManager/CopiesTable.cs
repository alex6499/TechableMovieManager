using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    class CopiesTable
    {

        private static TechableDSTableAdapters.CopiesTableAdapter adapter;

        private static TechableDSTableAdapters.CopiesTableAdapter getNewAdapter()
        {
            return new TechableDSTableAdapters.CopiesTableAdapter();
        }

        public static bool hasCopy(int upc)
        {
            bool hasCopy;

            adapter = getNewAdapter();
            DataTable table = adapter.GetCopy(upc);
            adapter.Dispose();

            hasCopy = table.Select().Length > 0;

            return hasCopy;
        }

        public static bool isAvailable(int upc)
        {
            bool isAvailable = false;

            adapter = getNewAdapter();
            DataTable table = adapter.GetCopy(upc);
            adapter.Dispose();

            if (table.Select().Length > 0)
            {
                isAvailable = (bool)table.Select()[0].ItemArray[2];
            }

            return isAvailable;
        }

        public static void makeAvailable(int upc)
        {
            setAvailable(true, upc);
        }
        public static void makeUnavailable(int upc)
        {
            setAvailable(false, upc);
        }
        public static void setAvailable(bool available, int upc)
        {
            adapter = getNewAdapter();
            adapter.UpdateAvailable(available, upc);
            adapter.Dispose();

        }

        public static DataTable getAll()
        {
            TechableDS.CopiesDataTable table;

            adapter = getNewAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(int upc, int movieId)
        {
            adapter = getNewAdapter();
            adapter.Insert(upc, movieId, true, false);
            adapter.Dispose();
        }
    }
}
