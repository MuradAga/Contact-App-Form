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
    public partial class Form4 : Form
    {
        int id;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool error = false;

            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True";
                string query = @$"INSERT INTO CONTACTS (NAME,SURNAME,COMPANY,COUNTRY_CODE,PREFIX,NUMBER,INSERT_USER)
                        VALUES ('{txtName.Text}','{txtSurname.Text}','{txtCompany.Text}','{txtCountryCode.Text}',
                        '{txtPrefix.Text}','{txtNumber.Text}',{id})";

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
                Form3 form3 = new Form3(id);
                form3.Show();
                this.Hide();
            }
        }
    }
}
