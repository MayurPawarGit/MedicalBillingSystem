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
    public partial class menu2 : Form
    { 
        
        public menu2()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            billing f1 = new billing();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addstock f1 = new addstock();
            f1.Show();
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form6 f1 = new Form6();
            f1.Show();
            this.Hide();
        }

        private void customerSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing ss = new billing();
            ss.Show();

           
        }

        private void stockAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void purchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void stockAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addstock f5 = new addstock();
            f5.Show();
           
        }

      

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();

            foreach(Form frm in this.MdiChildren)
            { 
                if(!frm.Focused)
                {
                    frm.Visible=false;
                    frm.Dispose();
                }
            }
        }

        private void stockCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salesreport s1 = new salesreport();
            s1.Show();
        }

        private void clientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client_report c1 = new client_report();
            c1.Show();

           
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchasereport p1 = new purchasereport();
            p1.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contact c1 = new contact();
            c1.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock_check s = new stock_check();
            s.Show();
        }

        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            Help c1 = new Help();
            c1.Show();
        }

        private void menu2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "B")
            {
                billing m = new billing();
                m.Show();

            }
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                addstock b = new addstock();
                b.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                salesreport s = new salesreport();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "P")
            {
                purchasereport s = new purchasereport();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "C")
            {
                client_report s = new client_report();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "H")
            {
                Help s = new Help();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "D")
            {
               dealerinfo s = new dealerinfo();
                s.Show();
            }
        }

        private void dealerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           dealerinfo s = new dealerinfo();
            s.Show();
        }

        private void menu2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client_report c1 = new client_report();
            c1.Show();

        }

        private void salesMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing ss = new billing();
            ss.Show();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addstock f5 = new addstock();
            f5.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();

            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            salesreport s1 = new salesreport();
            s1.Show();
        }

        private void purchaaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchasereport p1 = new purchasereport();
            p1.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

            contact c1 = new contact();
            c1.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

            Help c1 = new Help();
            c1.Show();
        }

        private void menu2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "B")
            {
                billing m = new billing();
                m.Show();

            }
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                addstock b = new addstock();
                b.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                salesreport s = new salesreport();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "P")
            {
                purchasereport s = new purchasereport();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "C")
            {
                client_report s = new client_report();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "H")
            {
                Help s = new Help();
                s.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                dealerinfo s = new dealerinfo();
                s.Show();
            }
        }

        private void dealerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dealerinfo s = new dealerinfo();
            s.Show();
        }

        private void menu2_Load_1(object sender, EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();

            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }
        }

        private void crToolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void menu2_FormClosing(object sender, FormClosingEventArgs e)
        {
            login f1 = new login();
            f1.Show();
            this.Hide();

            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }
        }
    }
}
