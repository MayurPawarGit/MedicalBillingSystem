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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WindowsFormsApplication30
{
    public partial class generate_bill : Form
    {
        int j;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
        int amo = 0;
        public generate_bill()
        {
            InitializeComponent();
        }
        public void get_value(int i)
        {
            j = i;
        }
     
         private void generate_bill_Load(object sender, EventArgs e)
           {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
             }
            conn.Open();


            DataSet2 ds2 = new DataSet2();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from order_user where id=" + j + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds2.DataTable1);


            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from order_item where order_id=" + j + "";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds2.DataTable2);
            da2.Fill(dt2);

            amo = 0;
            foreach (DataRow dr2 in dt2.Rows)
            {
                amo = amo + Convert.ToInt32(dr2["amount"].ToString());

            }


            CrystalReport2 myreport = new CrystalReport2();
            myreport.SetDataSource(ds2);
            // myreport.Refresh();
            myreport.SetParameterValue("amount", amo.ToString());
            crystalReportViewer1.ReportSource = myreport;
               //  crystalReportViewer1.Refresh(); 
             
            
        }

     

     

       
    }
}
