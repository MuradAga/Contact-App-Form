using System.Data.SqlClient;

namespace Contact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool error = false;
            int id = 0;
            try
            {
                string connectionString = "Server=MURAD;Database=Contact_App;Trusted_Connection=True";
                string query = @$"select ID from Users 
                where username = '{txtUsername.Text}' and PASSWORD = '{txtPassword.Text}'";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                id = cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                error = true;
            }

            if (error)
                MessageBox.Show("Xeta bas verdi");

            if (id == 0)
            {
                MessageBox.Show("Bele hesab yoxdur");
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