using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public static class MoviesTable
    {
        public static void add(int upc, string name, string date, string director)
        {
            DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
            adapter.InsertSansId(true, upc, name, date, director, false);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int movieId)
        {
            DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
            adapter.UpdateDeleted(deleted, movieId);
            adapter.Dispose();
        }

        public static void makeAvailable(int upc)
        {
            DataSet1TableAdapters.MoviesTableAdapter adapter = new DataSet1TableAdapters.MoviesTableAdapter();
            adapter.MakeAvailable(upc);
            adapter.Dispose();
        }
    }
}
