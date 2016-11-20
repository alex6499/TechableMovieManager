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

        public static bool hasCopy(string upc)
        {
            bool hasCopy;

            adapter = getNewAdapter();
            DataTable table = adapter.GetCopy(upc);
            adapter.Dispose();

            hasCopy = table.Select().Length > 0;

            return hasCopy;
        }

        public static bool hasCopyById(int movieId)
        {
            bool hasCopy;

            adapter = getNewAdapter();
            DataTable table = adapter.GetCopyById(movieId);
            adapter.Dispose();

            hasCopy = table.Select().Length > 0;

            return hasCopy;
        }

        public static bool isAvailable(string upc)
        {
            bool isAvailable = false;

            adapter = getNewAdapter();
            DataTable table = adapter.GetCopy(upc);
            adapter.Dispose();

            if (table.Select().Length > 0)
            {
                isAvailable = (bool)table.Select()[0].ItemArray[1];
            }

            return isAvailable;
        }

        public static void makeAvailable(string upc)
        {
            setAvailable(true, upc);
        }
        public static void makeUnavailable(string upc)
        {
            setAvailable(false, upc);
        }
        public static void setAvailable(bool available, string upc)
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

        public static void add(string upc, int movieId)
        {
            adapter = getNewAdapter();
            adapter.Insert(upc, movieId, true, false);
            adapter.Dispose();
        }
    }
}
