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

        public void add(int quantityTotal, int quantityAvailable, int upc, string name, string date, string director)
        {
            adapter.InsertSansId(quantityTotal, quantityAvailable, upc, name, date, director, false);
        }
    }
}
