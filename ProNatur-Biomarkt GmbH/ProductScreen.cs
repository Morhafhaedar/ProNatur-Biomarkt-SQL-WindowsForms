using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductScreen : Form
    {
        private SqlConnection dataBaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Morhaf.Haedar\Documents\Pro-Natur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");

        public ProductScreen()
        {
            InitializeComponent();
        }


        private void btnProductSave_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
            // save product name in database

        }
        private void btnProductEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {

        }

        private void btnproductDelete_Click(object sender, EventArgs e)
        {

        }


    }
}
