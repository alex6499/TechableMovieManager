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

        public static void makeAvailable(int upc)
        {
            adapter = getNewAdapter();
            adapter.UpdateAvailable(true, upc);
            adapter.Dispose();
        }
    }
}
