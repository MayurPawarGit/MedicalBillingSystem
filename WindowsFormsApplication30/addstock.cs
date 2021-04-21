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
    public partial class addstock : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
         // int count=0; 
        
        int i;
        public addstock()

        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            /*
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;

                comm.CommandText = "select * from medstocks where expdate <'" + dateTimePicker1.ToString() + "'";
                comm.ExecuteNonQuery();
                //int i = 0;
                //DataGridViewRow row = dataGridView1.Rows[i];


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox5.Text = dr["medname"].ToString();
                    dateTimePicker4.Text = dr["expdate"].ToString();
                }
                conn.Close();

                DateTime dt1 = DateTime.Parse(dateTimePicker4.Text);
                DateTime dt2 = DateTime.Parse(dateTimePicker1.Text);

                if (dt1.Date < dt2.Date)
                {
                MessageBox.Show(textBox5.Text + "Medicine is Expired.", "Expiry Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
                /*  string msg = "Medicine has Been Expired";
                  string title="Expiry Warning";
                  DialogResult result= MessageBox.Show(textBox5.Text +  msg,title );*/ 
                 dispdata();
             
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
       
        
        {
            if (textBox2.Text == "")
                MessageBox.Show("Please fill the medicine name");
            else if (textBox1.Text == "")
                MessageBox.Show("Please fill the Dealer Name");
           else if (textBox3.Text == "")
                MessageBox.Show("Please fill the medicine quantity");
           else if (textBox4.Text == "")
                MessageBox.Show("Please fill the medicine price");
            else if (comboBox11.Text == "")
                MessageBox.Show("Please select the medicine category");
            else
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "insert into medstocks values('" + textBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox11.Text + "','" + dateTimePicker2.Value + "','" + dateTimePicker3.Value + "','" + textBox6.Text + "')";
                comm.ExecuteNonQuery();
                conn.Close();
                dispdata();
                MessageBox.Show("Data are succefully insert");
                dateTimePicker2.Value = dateTimePicker1.Value;
                dateTimePicker3.Value = dateTimePicker1.Value;
                /* conn.Open();
                 SqlCommand com = conn.CreateCommand();
                 com.CommandType = CommandType.Text;
                 com.CommandText = "insert into stock values('" + textBox2.Text + "','" + textBox3.Text + "')";
                 com.ExecuteNonQuery();
                 conn.Close();*/

            }
           
            }
        public void dispdata()
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from medstocks ";
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
            textBox6.Text = "";
            comboBox11.Text = "";
        }
        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {  /*
            int a, b, c;
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
            c = a * b;
            textBox6.Text = c.ToString();  */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Double Click On Cell");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd7 = conn.CreateCommand();
                    cmd7.CommandType = CommandType.Text;
                    // cmd7.CommandText = "update medstocks set quantity='" + textBox3.Text + "' where medname='" + textBox2.Text + "'";
                    //cmd7.CommandText = "update medstocks set price='" + textBox4.Text + "' where medname='" + textBox2.Text + "'";
                    //cmd7.CommandText = "update medstocks set amount='" + textBox6.Text + "' where medname='" + textBox2.Text + "'";
                    cmd7.CommandText = "update medstocks set medname='" + textBox2.Text + "' where category='" + comboBox11.Text + "'";
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
                    cmd7.CommandText = "update medstocks set price='" + textBox4.Text + "' where medname='" + textBox2.Text + "'";
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
                    cmd7.CommandText = "update medstocks set quantity='" + textBox3.Text + "' where medname='" + textBox2.Text + "'";
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
                    cmd7.CommandText = "update medstocks set amount='" + textBox6.Text + "' where medname='" + textBox2.Text + "'";
                    cmd7.ExecuteNonQuery();
                    //  MessageBox.Show("Data Updated Successfully");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Data Updated Successfully");
            }
            dispdata();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            comboBox11.Text = "";

              
           /*/ conn.Open();
            OleDbCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from stock";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (textBox2.Text == "")
                MessageBox.Show("Please fill the medicine name");
            else if (textBox1.Text == "")
                MessageBox.Show("Please fill the Dealer Name");
            else if (textBox3.Text == "")
                MessageBox.Show("Please fill the medicine quantity");
            else if (textBox4.Text == "")
                MessageBox.Show("Please fill the medicine price");
            else if (comboBox11.Text == "")
                MessageBox.Show("Please select the medicine category");
            else
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "delete from medstocks where medstocks.medname='" + textBox2.Text + "'";
                comm.ExecuteNonQuery();
                conn.Close();
                dispdata();
                MessageBox.Show("Data are succefully Delete");
            }

          /*  DataTable dt = new DataTable();
            try
            {
                
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));
                dispdata();
                MessageBox.Show("Data are succefully Delete");
            }
            catch
            {
            }*/

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
          /*/  count = 0;
            conn.Open();
            OleDbCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from stock where id='" + textBox1.Text + "'";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(dt);
            count= Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            conn.Close();

            if (count == 0)
            {
                MessageBox.Show("Record not found");

            }*/
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from medstocks where medname like  '"+textBox2.Text+"%'";
       //  comm.CommandText = "select * from medstocks where dealername ='" + textBox1.Text + "%'";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

            menu2 f3 = new menu2();
            f3.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox2.Text=row.Cells[1].Value.ToString();
            dateTimePicker1.Text= row.Cells[2].Value.ToString();
            textBox1.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
           comboBox11.Text=row.Cells[6].Value.ToString();
           dateTimePicker2.Text = row.Cells[7].Value.ToString();
           dateTimePicker3.Text = row.Cells[8].Value.ToString();
            textBox6.Text = row.Cells[9].Value.ToString();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox4.Text));
                comboBox11.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            comboBox11.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
        }

        private void addstock_KeyDown(object sender, KeyEventArgs e)
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
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                dealerinfo s = new dealerinfo();
                s.Show();
            }
            if (e.Alt && e.KeyCode.ToString() == "A")
            {
                this.Close();
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dispdata();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            listBox1.Visible = true;
            listBox1.Items.Clear();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dealerinfo  where dealername like ('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["dealername"]).ToString();
            }
            conn.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex + 1;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex - 1;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    //textBox16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }


    }
}
