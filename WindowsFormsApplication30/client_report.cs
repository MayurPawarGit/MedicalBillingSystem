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
    public partial class client_report : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
        string query = "";
        public client_report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string startdate;
            string enddate;
            startdate = dateTimePicker1.Value.ToString("dd/mm/yyyy");
            enddate = dateTimePicker2.Value.ToString("dd/mm/yyyy");
          //  int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  order_user where date>='" + startdate.ToString() + "'AND date<='" + enddate.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*
            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["amount"].ToString());
            }
            label3.Text = i.ToString();*/
            query = "select * from order_user where date>='" + startdate.ToString() + "'AND date<='" + enddate.ToString() + "'";
        }

        private void client_report_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from order_user";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*
            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["amount"].ToString());
            }
            label3.Text = i.ToString();*/
            query = "select * from order_user";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generate_client_report gpr = new generate_client_report();
            gpr.get_value(query.ToString());
            gpr.Show();
        }
    }
}
