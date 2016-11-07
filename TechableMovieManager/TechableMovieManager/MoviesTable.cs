using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    public class MoviesTable
    {
        DataSet1.MoviesDataTable table;
        DataSet1TableAdapters.MoviesTableAdapter adapter;
        public MoviesTable()
        {
            table = new DataSet1.MoviesDataTable();
            adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        }

        public void add(bool available, int upc, string name, string date, string director)
        {
            adapter.InsertSansId(available, upc, name, date, director, false);
        }

        public void setDeleted(bool deleted, int movieId)
        {
            adapter.UpdateDeleted(deleted, movieId);
        }
    }
}
