using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobileStore
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            label1.Hide();
            label2.Hide();
            label3.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void billing_Click(object sender, EventArgs e)
        {
            this.Hide();
            billing b = new billing();
            b.Show();
        }

        private void billing_MouseHover(object sender, EventArgs e)
        {
            billingbtn.BackColor = Color.Orange;
            label1.Show();
        }


        private void billing_MouseLeave(object sender, EventArgs e)
        {
            billingbtn.BackColor = Color.WhiteSmoke;
            label1.Hide();
        }

        private void add_stockbtn_MouseHover(object sender, EventArgs e)
        {
            add_stockbtn.BackColor = Color.Orange;
            label2.Show();
        }

        private void add_stockbtn_MouseLeave(object sender, EventArgs e)
        {
            add_stockbtn.BackColor = Color.WhiteSmoke;
            label2.Hide();
        }

        private void stock_detailbtn_MouseHover(object sender, EventArgs e)
        {
            stock_detailbtn.BackColor = Color.Orange;
            label3.Show();
        }

        private void stock_detailbtn_MouseLeave(object sender, EventArgs e)
        {
            stock_detailbtn.BackColor = Color.WhiteSmoke;
            label3.Hide();
        }

        private void add_stockbtn_Click(object sender, EventArgs e)
        {
            add_stock f2 = new add_stock();
            this.Hide();
            f2.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void stock_detailbtn_Click(object sender, EventArgs e)
        {
            ViewStoc f3 = new ViewStoc();
            this.Hide();
            f3.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f0 = new Form1();
                f0.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            f3.Show();
            this.Hide();
        }



    }
}
