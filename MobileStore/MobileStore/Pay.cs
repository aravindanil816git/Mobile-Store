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
    public partial class Pay : Form
    {
        public Pay()
        {
            int total = 0;
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=NETWORKZ-PC;Initial Catalog=MobileStore;Integrated Security=True");
            con.Open();
            string billid = "SELECT bill_id,cust_name,address,contact,items,total FROM billing WHERE bill_id=(SELECT MAX(bill_id)  FROM billing)";
            SqlCommand cmd = new SqlCommand(billid, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                billNo.Text = (dr[0]).ToString();
                labelname.Text = (dr[2]).ToString();
                label3.Text = (dr[3]).ToString();
                contact.Text = (dr[0]).ToString();
                string items = dr[4].ToString();
                string price = dr[5].ToString();
                total = total + Convert.ToInt16(price);
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["item"].Value = items;
                dataGridView1.Rows[index].Cells["price"].Value =  price.ToString();
            }
            this.dataGridView1.Rows.Add("TOTAL ", total);
            con.Close();

        }

        private void Pay_Load(object sender, EventArgs e)
        {

        }


        private void print_button_Click(object sender, EventArgs e)
        {
          /*  SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }*/
        }

        /*  public void Export_Data_To_Word(DataGridView DGV, string filename)
          {
              if (DGV.Rows.Count != 0)
              {
                  int RowCount = DGV.Rows.Count;
                  int ColumnCount = DGV.Columns.Count;
                  Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                  //add rows
                  int r = 0;
                  for (int c = 0; c <= ColumnCount - 1; c++)
                  {
                      for (r = 0; r <= RowCount - 1; r++)
                      {
                          DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                      } //end row loop
                  } //end column loop

                  Word.Document oDoc = new Word.Document();
                  oDoc.Application.Visible = true;

                  //page orintation
                  oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                  dynamic oRange = oDoc.Content.Application.Selection.Range;
                  string oTemp = "";
                  for (r = 0; r <= RowCount - 1; r++)
                  {
                      for (int c = 0; c <= ColumnCount - 1; c++)
                      {
                          oTemp = oTemp + DataArray[r, c] + "\t";

                      }
                  }

                  //table format
                  oRange.Text = oTemp;

                  object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                  object ApplyBorders = true;
                  object AutoFit = true;
                  object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                  oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                        Type.Missing, Type.Missing, ref ApplyBorders,
                                        Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                  oRange.Select();

                  oDoc.Application.Selection.Tables[1].Select();
                  oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                  oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                  oDoc.Application.Selection.Tables[1].Rows[1].Select();
                  oDoc.Application.Selection.InsertRowsAbove(1);
                  oDoc.Application.Selection.Tables[1].Rows[1].Select();

                  //header row style
                  oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                  oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                  oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                  //add header row manually
                  for (int c = 0; c <= ColumnCount - 1; c++)
                  {
                      oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                  }

                  //table style 
                  oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                  oDoc.Application.Selection.Tables[1].Rows[1].Select();
                  oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                  //header text
                  foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                  {
                      Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                      headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                      headerRange.Text = "your header text";
                      headerRange.Font.Size = 16;
                      headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                  }

                  //save the file
                  oDoc.SaveAs2(filename);

              }
          }*/


    }

}
