using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public static class MoviesTable
    {
        private static TechableDSTableAdapters.MoviesTableAdapter adapter;

        private static TechableDSTableAdapters.MoviesTableAdapter getNewAdapter()
        {
            return new TechableDSTableAdapters.MoviesTableAdapter();
        }

        public static DataTable getAll()
        {
            TechableDS.MoviesDataTable table;

            adapter = getNewAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(string name, int year, string studio)
        {
            adapter = getNewAdapter();
            adapter.Insert(name, year, studio, false, 0);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int movieId)
        {
            adapter = getNewAdapter();
            adapter.UpdateDeleted(deleted, movieId);
            adapter.Dispose();
        }

        public static void makeAvailable(int upc)
        {
            adapter = getNewAdapter();
            adapter.MakeAvailable(upc);
            adapter.Dispose();
        }
    }
}
