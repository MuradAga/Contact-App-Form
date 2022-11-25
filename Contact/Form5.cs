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
    public partial class Form5 : Form
    {
        int contactId;
        int id;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(int contactId, int id)
        {
            this.contactId = contactId;
            this.id = id;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True;";
                string query = $@"UPDATE CONTACTS SET NAME='{txtName.Text}',
            SURNAME='{txtSurname.Text}',COMPANY='{txtCompany.Text}',COUNTRY_CODE='{txtCountryCode.Text}',
            PREFIX='{txtPrefix.Text}',NUMBER='{txtNumber.Text}' WHERE ID={contactId}";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

                Form3 form3 = new Form3(id);
                form3.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Xeta bas verdi");
            }
        }
    }
}
