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
    public partial class billing : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Shree\Documents\Visual Studio 2012\Projects\WindowsFormsApplication30\WindowsFormsApplication30\medsystem.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        int amount = 0;

        public billing()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            dt.Clear();
            dt.Columns.Add("medname");
            dt.Columns.Add("price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("amount");
        }









        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }







        private void textBox15_KeyUp(object sender, KeyEventArgs e)
        {
            listBox2.Visible = true;
            listBox2.Items.Clear();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from medstocks where medname like ('" + textBox15.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox2.Items.Add(dr["medname"]).ToString();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox2.Focus();
                listBox2.SelectedIndex = 0;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBox2.SelectedIndex = this.listBox2.SelectedIndex + 1;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.listBox2.SelectedIndex = this.listBox2.SelectedIndex - 1;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    textBox15.Text = listBox2.SelectedItem.ToString();
                    listBox2.Visible = false;
                    textBox16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox18.Text = Convert.ToString(Convert.ToInt32(textBox16.Text) * Convert.ToInt32(textBox17.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from medstocks where medname='" + textBox15.Text + "' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox16.Text = dr["price"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
                MessageBox.Show("Please fill the medicine name");
            else if (textBox17.Text == "")
                MessageBox.Show("Please fill the medicine quantity");

            else
            {
                int stock = 0;
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from medstocks where medname='" + textBox15.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    stock = Convert.ToInt32(dr1["quantity"].ToString());
                }
                if (Convert.ToInt32(textBox17.Text) > stock)
                {
                    MessageBox.Show("This much quantity is not available");
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["medname"] = textBox15.Text;
                    dr["price"] = textBox16.Text;
                    dr["quantity"] = textBox17.Text;
                    dr["amount"] = textBox18.Text;
                    textBox1.Text = "";
                    dt.Rows.Add(dr);
                    dataGridView2.DataSource = dt;

                    amount = amount + Convert.ToInt32(dr["amount"].ToString());
                    label22.Text = amount.ToString();
                }

                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
                amount = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView2.CurrentCell.RowIndex.ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    amount = amount + Convert.ToInt32(dr1["amount"].ToString());
                    label22.Text = amount.ToString();
                }
            }
            catch
            {
                MessageBox.Show("There was an error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
                MessageBox.Show("Please fill the customer name");
            else if (textBox11.Text == "")
                MessageBox.Show("Please fill the Address");
            else if (textBox12.Text == "")
                MessageBox.Show("Please fill the City Name");
            else if (textBox13.Text == "")
                MessageBox.Show("Please fill the Mobile Number");
            else if (textBox14.Text == "")
                MessageBox.Show("Please fill the Doctor Name");
            else if (amount == 0)
                MessageBox.Show("Please Enter the Medicine Name");
            else
            {


                string orderid = "";
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into order_user values ('" + textBox19.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + dateTimePicker2.Value + "')";
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select top 1 * from order_user order by id desc";
                cmd2.ExecuteNonQuery();

                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    orderid = dr2["id"].ToString();
                }


                foreach (DataRow dr in dt.Rows)
                {
                    int quantity = 0;
                    string medname = "";


                    SqlCommand cmd3 = conn.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into order_item values('" + orderid.ToString() + "','" + dr["medname"].ToString() + "','" + dr["price"].ToString() + "','" + dr["quantity"].ToString() + "','" + dr["amount"].ToString() + "')";
                    cmd3.ExecuteNonQuery();
                    quantity = Convert.ToInt32(dr["quantity"].ToString());
                    medname = dr["medname"].ToString();

                    SqlCommand cmd6 = conn.CreateCommand();
                    cmd6.CommandType = CommandType.Text;
                    cmd6.CommandText = "update medstocks set quantity=quantity-" + quantity + " where medname='" + medname.ToString() + "'";
                    cmd6.ExecuteNonQuery();


                    SqlCommand cmd7 = conn.CreateCommand();
                    cmd7.CommandType = CommandType.Text;
                    cmd7.CommandText = "update medstocks set amount=amount-" + amount + " where medname='" + medname.ToString() + "'";
                    cmd7.ExecuteNonQuery();


                }

                textBox19.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";

                dt.Clear();
                dataGridView2.DataSource = dt;
                //   MessageBox.Show("record inserted successfully");

                generate_bill gb = new generate_bill();
                gb.get_value(Convert.ToInt32(orderid.ToString()));
                gb.Show();
            }

        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from order_user where drname  like ('" + textBox14.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["drname"]).ToString();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
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
                    textBox14.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    textBox15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Enter(object sender, EventArgs e)
        {
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from medstocks where medname='" + textBox15.Text + "' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["quantity"].ToString();
            }
        }

        private void billing_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Control && e.KeyCode.ToString() == "M")
            {
                menu2 m = new menu2();
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
            if (e.Alt && e.KeyCode.ToString() == "A")
            {
                this.Close();
            }



        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetterOrDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetterOrDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter a valid value");
            }
        }


    }
}

     

       
    

