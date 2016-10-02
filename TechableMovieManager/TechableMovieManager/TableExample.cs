using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public partial class TableExample : Form
    {
        public TableExample()
        {
            InitializeComponent();
        }

        private void TableExample_Load(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "Test";
           
        }
    }
}
