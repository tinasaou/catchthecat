using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatchTheCat
{
    
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        //string connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Game_user.mdb";
        String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.mdb;";
   
  
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            StringBuilder sb = new StringBuilder();
            String query = "Select score from Game where name ='" + textBox1.Text + "';";
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string aaa = reader.GetString(0);
                    sb.Append(Environment.NewLine);
                    MessageBox.Show("Hello Akis your score is " + aaa);
                }
            }
            else
            {
                MessageBox.Show("new Player");
                insert();
                
                            }
            connection.Close();
        }
        /*public void insert() { 
            connection.Open();
            String name = textBox1.Text;
            OleDbCommand command = connection.CreateCommand();
            //StringBuilder sb2 = new StringBuilder();
            String query = "Insert into Game([name]) values(@name)";
            command.CommandText = query;
            command.Parameters.AddRange(new OleDbParameter[] {
            new OleDbParameter("name", name)
            }); ;
            connection.Close();
        }
        */
        public void insert()
        {
            string name = textBox1.Text;
            string query = "INSERT INTO Game ([name]) VALUES (@name)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
