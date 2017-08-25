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
    public partial class add_stock : Form
    {
        SqlConnection con = new SqlConnection("Data Source=NETWORKZ-PC;Initial Catalog=MobileStore;Integrated Security=True");
        public add_stock()
        {
            InitializeComponent();
            panel2.Hide();
        }

        private void add_stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mobileStoreDataSet1.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.mobileStoreDataSet1.stock);
            panel1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NETWORKZ-PC;Initial Catalog=MobileStore;Integrated Security=True");
            con.Open();
            string update="INSERT INTO stock(p_code,name,qty,price) VALUES('"+pcode.Text+"','"+pname.Text+"',"+Convert.ToInt16(qty.Text)+","+Convert.ToInt16(price.Text)+")";
            SqlCommand cmd = new SqlCommand(update, con);
            int returnvalue=cmd.ExecuteNonQuery();
            if (returnvalue!=0)
                MessageBox.Show("Added Successfully");
            con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            string update = "UPDATE stock SET qty=" + qtynew.Text + ",price=" + pricenew.Text + " WHERE p_code='" + pcode_update.Text + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            int returnvalue = cmd.ExecuteNonQuery();
            if (returnvalue != 0)
                MessageBox.Show("Added Successfully");
            con.Close();
        }

        private void pcode_update_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string update_var = "SELECT qty,price FROM stock WHERE p_code='" + pcode_update.Text + "'";
            SqlCommand cmd = new SqlCommand(update_var, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int qty = Convert.ToInt16((dr[0]));
            int price = Convert.ToInt16((dr[1]));
            pricenew.Text=price.ToString();
            qtynew.Text = qty.ToString();
            con.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }
    }
}
