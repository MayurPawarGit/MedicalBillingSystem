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

namespace WindowsFormsApplication30
{
    public partial class purchasereport : Form
    {
       
       SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
       string query = "";
        public purchasereport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from medstocks";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                i = i +Convert.ToInt32( dr["amount"].ToString());
            }
            label3.Text = i.ToString();
            query = "select * from medstocks";

        }

        private void purchasereport_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string startdate;
            string enddate;
            startdate = dateTimePicker1.Value.ToString("dd/mm/yyyy");
           enddate = dateTimePicker2.Value.ToString("dd/mm/yyyy");
            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from medstocks where purchasedate>='" + startdate.ToString() + "'AND purchasedate<='"+enddate.ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["amount"].ToString());
            }
            label3.Text = i.ToString();
            query = "select * from medstocks where purchasedate>='" + startdate.ToString() + "'AND purchasedate<='"+enddate.ToString()+ "'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate_purchase_report gpr = new generate_purchase_report();
            gpr.get_value(query.ToString());
            gpr.Show();
        }
    }
}
