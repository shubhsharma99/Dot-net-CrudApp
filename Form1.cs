using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Crudapp
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            conn = new SqlConnection("Data Source=DESKTOP-GKIHNSB\\SQLEXPRESS;Initial Catalog=CRUDForm;Integrated Security=True;Encrypt=False");
            cmd = new SqlCommand();
            cmd.Connection = conn;

            adapter = new SqlDataAdapter(cmd);
            dataTable = new DataTable();


        }

        private void create_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                string query = "INSERT INTO table_user VALUES(@ID, @Name, @Age)";
                cmd.CommandText = query;

               
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); 
            }


        }

        private void Update_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "UPDATE table_user SET Name = @Name, Age = @Age WHERE ID = @ID";
                cmd.CommandText = query;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records updated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }


    }
}
    

       
            
        
    

