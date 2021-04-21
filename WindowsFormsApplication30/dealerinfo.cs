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
    public partial class dealerinfo : Form
    { SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
   
        int i;
        public dealerinfo()
        {
            InitializeComponent();
        }
        private void dealerinfo_Load(object sender, EventArgs e)
        {
            dispdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (textBox1.Text == "")
                MessageBox.Show("Please fill the Dealer Name");
            else if (textBox2.Text == "")
                MessageBox.Show("Please fill the Dealer Address");
           else if (textBox3.Text == "")
                MessageBox.Show("Please fill the Contact Number");
           else if (textBox4.Text == "")
                MessageBox.Show("Please fill Email");
          
            else
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "insert into dealerinfo values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                comm.ExecuteNonQuery();
                conn.Close();
                dispdata();
                MessageBox.Show("Data are succefully insert");
               
            }
           
            }
        public void dispdata()
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from dealerinfo ";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            dataGridView1.DataSource=dt;
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
           
        }

        private void dealerinfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "M")
            {
                menu2 m = new menu2();
                m.Show();
            }
            if (e.Control && e.KeyCode.ToString() == "B")
            {
                billing b = new billing();
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
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                addstock s = new addstock();
                s.Show();
            }
            if (e.Alt && e.KeyCode.ToString() == "A")
            {
                this.Close();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
                cmd7.CommandText = "update dealerinfo set dealername='" + textBox1.Text + "' where contactno='" + textBox3.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set dealeraddress='" + textBox2.Text + "' where contactno='" + textBox3.Text + "'";
               // cmd7.CommandText = "update dealerinfo set contactno='" + textBox3.Text + "' where dealername='" + textBox1.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set emailaddress='" + textBox4.Text + "' where contactno='" + textBox3.Text + "'";
                cmd7.ExecuteNonQuery();

              //  MessageBox.Show("Data Updated Successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                conn.Open();
                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
               // cmd7.CommandText = "update dealerinfo set dealername='" + textBox1.Text + "' where contactno='" + textBox3.Text + "'";
                cmd7.CommandText = "update dealerinfo set dealeraddress='" + textBox2.Text + "' where contactno='" + textBox3.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set contactno='" + textBox3.Text + "' where dealername='" + textBox1.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set emailaddress='" + textBox4.Text + "' where contactno='" + textBox3.Text + "'";
                cmd7.ExecuteNonQuery();

               // MessageBox.Show("Data Updated Successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                conn.Open();
                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
               // cmd7.CommandText = "update dealerinfo set dealername='" + textBox1.Text + "' where contactno='" + textBox3.Text + "'";
               // cmd7.CommandText = "update dealerinfo set dealeraddress='" + textBox2.Text + "' where contactno='" + textBox3.Text + "'";
               cmd7.CommandText = "update dealerinfo set contactno='" + textBox3.Text + "' where dealername='" + textBox1.Text + "'";
                //cmd7.CommandText = "update dealerinfo set emailaddress='" + textBox4.Text + "' where contactno='" + textBox3.Text + "'";
                cmd7.ExecuteNonQuery();

              //  MessageBox.Show("Data Updated Successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                conn.Open();
                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
              //  cmd7.CommandText = "update dealerinfo set dealername='" + textBox1.Text + "' where contactno='" + textBox3.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set dealeraddress='" + textBox2.Text + "' where contactno='" + textBox3.Text + "'";
              //  cmd7.CommandText = "update dealerinfo set contactno='" + textBox3.Text + "' where dealername='" + textBox1.Text + "'";
                cmd7.CommandText = "update dealerinfo set emailaddress='" + textBox4.Text + "' where contactno='" + textBox3.Text + "'";
                cmd7.ExecuteNonQuery();

               // MessageBox.Show("Data Updated Successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Data Updated Successfully");
            dispdata();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();



        
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Please select the dealername");
            else if (textBox2.Text == "")
                MessageBox.Show("Please fill the address");
            else if (textBox3.Text == "")
                MessageBox.Show("Please fill the contact number");
            else if (textBox4.Text == "")
                MessageBox.Show("Please fill the email");
            else
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "delete from dealerinfo where dealerinfo.dealername='" + textBox1.Text + "'";
                comm.ExecuteNonQuery();
                conn.Close();
                dispdata();
                MessageBox.Show("Data are succefully Delete");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetterOrDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

      
        
        }
    }

