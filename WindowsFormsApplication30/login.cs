using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace WindowsFormsApplication30
{
    public partial class login : Form
    {
        public login()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }
       public void StartForm()
        {
            Application.Run(new splashscreen());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Parse("11/11/2095");
            if (d1.Date > d2.Date)
            {
                MessageBox.Show("Your Application is Expired");  

            }
            else
            {

                 SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select count (*) from useradd  where username='" + textBox1.Text.ToString() + "' AND password='" + textBox2.Text.ToString() + "' ", con);
                con.Open();
                int i;
                i = Convert.ToInt32(cmd.ExecuteScalar());
                if (i == 1)
                {
                    MessageBox.Show("Login Successfully");
                    menu2 m = new menu2();
                    m.Show();
                    
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username And Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Do you really wants to close the Application?", "Exit", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (d==DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
