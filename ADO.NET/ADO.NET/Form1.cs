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
using System.Data; // Data Table

namespace ADO.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string connectionStr = "Server=INSTRUCTORIT; Database=IBTCollege; User Id=ProfileUser; Password=ProfileUser2019";

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                string cmdTextDelete = "DELETE FROM Students WHERE Id =1";
                SqlCommand cmdDelete = new SqlCommand(cmdTextDelete, conn);
                int rowsAffected = cmdDelete.ExecuteNonQuery(); // Insert Update or Delete
                Console.WriteLine("{0} row affected", rowsAffected.ToString());

            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {

            string connectionStr = "Server=INSTRUCTORIT; Database=IBTCollege; User Id=ProfileUser; Password=ProfileUser2019";

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();


                string commandText = String.Format("SELECT * FROM Students ");
                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDataReader reader = cmd.ExecuteReader(); // select
                while (reader.Read())
                {
                    string fullName = reader["firstName"] + " " + reader["lastName"];
                    // string fullName = reader[1] + " " + reader[2]
                    listBox1.Items.Add(fullName);


                }
                reader.Close();
                
                //read results
            }
                
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            string connectionStr = "Server=INSTRUCTORIT; Database=IBTCollege; User Id=ProfileUser; Password=ProfileUser2019";

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                string cmdTextInsert = "Insert Into Students Value (Id =1, fisrtName= Goutam, lastName= Das)";
                SqlCommand cmdInsert = new SqlCommand(cmdTextInsert, conn);
                int rowsAffected = cmdInsert.ExecuteNonQuery(); // Insert Update or Delete
                Console.WriteLine("{0} row affected", rowsAffected.ToString());

            }
        }
    }
}
