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
        public static DataTable getAll()
        {
            DataSet2.MoviesDataTable table;

            DataSet2TableAdapters.MoviesTableAdapter adapter = new DataSet2TableAdapters.MoviesTableAdapter();
            table = adapter.GetData();
            adapter.Dispose();

            return table;
        }

        public static void add(int upc, string name, string date, string director)
        {
            DataSet2TableAdapters.MoviesTableAdapter adapter = new DataSet2TableAdapters.MoviesTableAdapter();
            adapter.InsertSansId(true, upc, name, date, director, false);
            adapter.Dispose();
        }

        public static void setDeleted(bool deleted, int movieId)
        {
            DataSet2TableAdapters.MoviesTableAdapter adapter = new DataSet2TableAdapters.MoviesTableAdapter();
            adapter.UpdateDeleted(deleted, movieId);
            adapter.Dispose();
        }

        public static void makeAvailable(int upc)
        {
            DataSet2TableAdapters.MoviesTableAdapter adapter = new DataSet2TableAdapters.MoviesTableAdapter();
            adapter.MakeAvailable(upc);
            adapter.Dispose();
        }
    }
}
