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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\onlineshoppingsystemdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                Con.Open();

                string query = "INSERT INTO CategoryTable (CatId, CatName, CatDesc) VALUES (@CatId, @CatName, @CatDesc)";
                SqlCommand cmd = new SqlCommand(query, Con);

                // Set parameter values
                cmd.Parameters.AddWithValue("@CatId", CatIdTb.Text);
                cmd.Parameters.AddWithValue("@CatName", CatNameTb.Text);
                cmd.Parameters.AddWithValue("@CatDesc", CatDescTb.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                // Close the database connection
                Con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "Select * from CategoryTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(CatIdTb.Text == "")
                {
                    MessageBox.Show("Select The Category to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from CategoryTable where CatId= " + CatIdTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CatDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    string query = "update CategoryTable set CatName = " + CatNameTb.Text + ", CatDesc = " + CatDescTb.Text + ", CatId = " + CatIdTb.Text + ";";
                    SqlCommand cmb = new SqlCommand(query, Con);
                    cmb.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully updated");
                    Con.Close();
                    populate();
                }




            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 prod= new Form2();
            prod.Show();
            this.Hide();
        }
    }
}
