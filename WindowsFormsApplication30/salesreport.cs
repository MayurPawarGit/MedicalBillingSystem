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
    public partial class salesreport : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
        string query = "";
       
        public salesreport()
        {
           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from order_user,order_item";
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
            query = "select * from order_user,order_item";
           
           
        }

        private void salesreport_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generate_sales_report gpr = new  generate_sales_report();
            gpr.get_value(query.ToString());
            gpr.Show();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string startdate;
            string enddate;
            startdate = dateTimePicker1.Value.ToString("dd/mm/yyyy");
            enddate = dateTimePicker2.Value.ToString("dd/mm/yyyy");
            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "select * from order_user,order_item where date>='" + startdate.ToString() + "'AND date<='" + enddate.ToString() + "'";
            //cmd.CommandText = "select * from order_item where  medname ='" + textBox1.Text + "'";
            //cmd.CommandText = "select * from order_item,order_user where  customername ='" + textBox2.Text + "'";
            cmd.CommandText = "select * from order_item where  order_id ='" + textBox3.Text + "'";
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
            query = "select * from order_user,order_item where date>='" + startdate.ToString() + "'AND date<='" + enddate.ToString() + "'";

            


            //conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from order_user where  customername like'" + textBox2.Text + "%'";
          //  comm.CommandText = "select * from medstocks where dealername ='" + textBox1.Text + "%'";
            comm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(comm);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
          //  conn.Close();
           /*
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from order_item where  medname ='" + textBox1.Text + "'";
            comm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(comm);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;*/
          
        
        
        
        
        
        
        
        
        
        
        
        }


       
    }
}
