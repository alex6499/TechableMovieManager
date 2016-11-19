using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    class DVD
    {
        private string movieName;
        private int upc;

        public DVD(string movieName, int upc)
        {
            this.movieName = movieName;
            this.upc = upc;
        }

        public string getMovieName()
        {
            return movieName;
        }

        public int getUpc()
        {
            return upc;
        }
    }
}
