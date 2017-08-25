using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileStore
{
    public partial class ViewStoc : Form
    {
        public ViewStoc()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ViewStoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'manufacturer.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter2.Fill(this.manufacturer.stock);
            // TODO: This line of code loads data into the 'mobileStoreDataSet.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter1.Fill(this.mobileStoreDataSet.stock);
            // TODO: This line of code loads data into the 'allStockList.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.allStockList.stock);

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NETWORKZ-PC;Initial Catalog=MobileStore;Integrated Security=True");   
            con.Open();
            string viewstck = "SELECT id,p_code,name,qty,price,manufacturer FROM stock WHERE manufacturer='"+category.Text+"'";
            SqlDataAdapter cmd = new SqlDataAdapter(viewstck, con);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.Refresh();
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog p = new PrintDialog();
            p.ShowDialog();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Wheat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }


    }
}
