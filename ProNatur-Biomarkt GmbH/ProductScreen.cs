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
        private int lastSelectedProductKey;
        public ProductScreen()
        {
            InitializeComponent();

            //start
            ShowProduct();

        }

        private void ShowProduct()
        {
            dataBaseConnection.Open();

            string query = "select * from Product";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, dataBaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            productDGV.DataSource = dataSet.Tables[0];

            productDGV.Columns[0].Visible = false;



            dataBaseConnection.Close();
        }

        private void ClearAll()
        {
            textBoxProductName.Text = string.Empty;
            textBoxBrand.Text = string.Empty;
            textBoxProductPreis.Text = string.Empty;
            comboBoxproductCategory.Text = string.Empty;
            comboBoxproductCategory.SelectedItem = null;
        }

        private void ExecuteQuery(string query)
        {
            dataBaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, dataBaseConnection);
            sqlCommand.ExecuteNonQuery();
            dataBaseConnection.Close();
        }
        private void btnProductSave_Click(object sender, EventArgs e)
        {   
            if(textBoxProductName.Text == null
                || textBoxBrand.Text ==null
                || textBoxProductPreis.Text ==null
                || comboBoxproductCategory.Text == null
                )
            {
                MessageBox.Show("All fildes have to be full");

                return;
            }
            string productName     = textBoxProductName.Text;
            string procuctBrand    = textBoxBrand.Text;
            string productPreis    = textBoxProductPreis.Text;
            string productCatagory = comboBoxproductCategory.Text;

            // save product new in database
            string query = string.Format("insert into Product Values('{0}', '{1}', '{2}','{3}')", productName,
                                            procuctBrand, productCatagory, productPreis);
            ExecuteQuery(query);
            ClearAll();
            ShowProduct();

        }
        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                return;
            }

            string query = string.Format("update Product set Name= '{0}', Brand='{1}', Catagory='{2}', Price='{3}' where Id={4}"
                , textBoxProductName.Text, textBoxBrand.Text, comboBoxproductCategory.Text, textBoxProductPreis.Text, lastSelectedProductKey);

            ExecuteQuery(query);

            ClearAll();
            ShowProduct();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {


            ClearAll();
            
        }

        private void btnproductDelete_Click(object sender, EventArgs e)
        {
            if(lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                return;
            }
            string query = string.Format("delete from Product where Id = {0};",lastSelectedProductKey);
            ExecuteQuery(query);

            ClearAll();
            ShowProduct();
        }

        private void productDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductName.Text         = productDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxBrand.Text               = productDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBoxProductPreis.Text        = productDGV.SelectedRows[0].Cells[4].Value.ToString();
            comboBoxproductCategory.Text    = productDGV.SelectedRows[0].Cells[3].Value.ToString();
            lastSelectedProductKey          = (int)productDGV.SelectedRows[0].Cells[0].Value;

        }
    }
}
