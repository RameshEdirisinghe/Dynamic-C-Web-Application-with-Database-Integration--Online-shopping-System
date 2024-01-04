using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace OnlineShoppingSystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\onlineshoppingsystemdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Sellersss()
        {
            Con.Open();
            string query = "Select * from SellerTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Sellersss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                Con.Open();

                string query = "INSERT INTO SellerTable (SellersId, SellersName, SellersPhone, SellersAge, SellersPassword) VALUES (@SellersId, @SellersName, @SellersPhone, @SellersPassword, @SellersAge)";
                SqlCommand cmd = new SqlCommand(query, Con);

                // Set parameter values
                cmd.Parameters.AddWithValue("SellersId", SellersId.Text);
                cmd.Parameters.AddWithValue("SellersName", SellersName.Text);
                cmd.Parameters.AddWithValue("@SellersPhone", SellersPhone.Text);
                cmd.Parameters.AddWithValue("@SellersAge", SellersAge.Text);
                cmd.Parameters.AddWithValue("@SellersPassword", SellersPassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");
                // Close the database connection
                Con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SellersId.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            SellersName.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SellersAge.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SellersPhone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            SellersPassword.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
