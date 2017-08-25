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
    public partial class billing : Form
    {

        SqlConnection con = new SqlConnection("Data Source=NETWORKZ-PC;Initial Catalog=MobileStore;Integrated Security=True");   
        public billing()
        {
            InitializeComponent();
            con.Open();
            string billid = "SELECT (MAX(bill_id)+1) FROM billing";
            SqlCommand cmd = new SqlCommand(billid, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            bill_no.Text = (dr[0]).ToString();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemsBox1.Items.Add(comboBox1.Text);

        }

        private void billing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mobileStoreDataSet.stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.mobileStoreDataSet.stock);

        }

        private void ItemsBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemsBox1.Items.Remove(ItemsBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open(); 
            foreach (object ob in ItemsBox1.Items)
            {
                string item = ob.ToString();
                string update1 = "UPDATE stock SET qty= (SELECT qty-1 FROM stock WHERE name='"+item+"') WHERE name='"+ob.ToString()+"'";  
                SqlCommand cmd1 = new SqlCommand(update1, con);
                cmd1.ExecuteNonQuery();
                

                string priceqry = "SELECT price FROM stock WHERE name='"+item+"'";
                SqlCommand cmdprice = new SqlCommand(priceqry, con);
                SqlDataReader dr = cmdprice.ExecuteReader();
                dr.Read();
                string price = (dr[0]).ToString();
                dr.Close();

                string update = "INSERT INTO  billing(bill_id,cust_name,address,contact,items,total) VALUES("+bill_no.Text+",'" + cust_name.Text + "','" + address.Text + "'," + contact.Text + ",'" + item + "',"+price+")";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                //items =items+","+ob.ToString();
            }

            Pay p = new Pay();
            p.Show();
            this.Hide();
            con.Close();
        }

        private void bill_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
