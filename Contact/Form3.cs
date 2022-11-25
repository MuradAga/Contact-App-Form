using System.Data;
using System.Data.SqlClient;

namespace Contact
{
    public partial class Form3 : Form
    {
        int id;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True;";
                string query = @$"SELECT * FROM CONTACTS WHERE INSERT_USER={id}";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Xeta bas verdi");
            }
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(id);
            form4.Show();
            this.Hide();
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True;";
                DataGridViewRow drow = dataGridView1.SelectedRows[0];
                int contactId = Convert.ToInt32(drow.Cells[0].Value);

                string query = @$"SELECT * FROM CONTACTS WHERE ID={contactId}";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Form5 form5 = new Form5(contactId, id);

                while (reader.Read())
                {
                    form5.txtName.Text = reader["NAME"].ToString();
                    form5.txtSurname.Text = reader["SURNAME"].ToString();
                    form5.txtCompany.Text = reader["COMPANY"].ToString();
                    form5.txtCountryCode.Text = reader["COUNTRY_CODE"].ToString();
                    form5.txtPrefix.Text = reader["PREFIX"].ToString();
                    form5.txtNumber.Text = reader["NUMBER"].ToString();
                }

                connection.Close();

                form5.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Xeta bas verdi");
            }
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Kontakti silmek isteyirsiniz ?","Sual",MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True;";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();

                    foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
                    {
                        int contactId = Convert.ToInt32(drow.Cells[0].Value);

                        string query = $@"DELETE FROM CONTACTS WHERE ID={contactId}";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.ExecuteNonQuery();
                    }

                    string query2 = @$"SELECT * FROM CONTACTS WHERE INSERT_USER={id}";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[7].Visible = false;

                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xeta bas verdi");
            }
        }

        private void gETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int contactId = Convert.ToInt32(drow.Cells[0].Value);

                string query = $@"SELECT * FROM CONTACTS WHERE ID={contactId}";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

                connection.Close();
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }
    }
}
