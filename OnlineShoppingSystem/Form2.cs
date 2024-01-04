using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineShoppingSystem
{
    public partial class Form2 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\onlineshoppingsystemdb.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }
        
        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
private void fillcombo()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CatName FROM CategoryTable", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatName", typeof(string));
                dt.Load(rdr);
                CatCb.ValueMember = "CatName";
                CatCb.DataSource = dt;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 cat = new Form4();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdId.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    string query = "update ProductTable set ProdName = " + ProdName.Text + ", ProdPrice = " + ProdPrice.Text + ", ProdId = " + ProdId.Text + ",ProdQty = " + ProdQty.Text + ", " + CatCb.SelectedValue.ToString() + "";
                    SqlCommand cmb = new SqlCommand(query, Con);
                    cmb.ExecuteNonQuery();
                    MessageBox.Show("Product Successfully updated");
                    Con.Close();
                    //populate();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdId.Text = ProdDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = ProdDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
