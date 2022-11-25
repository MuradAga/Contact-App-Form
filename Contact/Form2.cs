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

namespace Contact
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool error = false;

            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True";
                string query = @$"INSERT INTO USERS (USERNAME,PASSWORD,EMAIL)
                        VALUES ('{txtUsername.Text}','{txtPassword.Text}','{txtEmail.Text}')";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                error = true;
            }

            if (error)
            {
                MessageBox.Show("Xeta bas verdi");
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }
    }
}