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
    public partial class generate_purchase_report : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
        string j;
        int amo=0;
        public void get_value(string i)
        {
            j = i;
        }
        public generate_purchase_report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void generate_purchase_report_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            DataSet3 ds2 = new DataSet3();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds2.DataTable1);
            da.Fill(dt);

          

            amo = 0;
            foreach (DataRow dr in dt.Rows)
            {
                amo = amo + Convert.ToInt32(dr["amount"].ToString());

            }


            CrystalReport3 myreport = new CrystalReport3();
            myreport.SetDataSource(ds2);
            // myreport.Refresh();
            myreport.SetParameterValue("amount", amo.ToString());
            crystalReportViewer1.ReportSource = myreport;
            //  crystalReportViewer1.Refresh(); 
        }
    }
}
