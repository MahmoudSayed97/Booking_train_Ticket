using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class addAdmin : Form
    {
        DP d = new DP();
        public addAdmin()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
        }
        string query;MySqlCommand cmd;MySqlDataReader datareader;
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text == "")
                label5.Text = "ادخل الرقم القومي اولا";
           else if (textBox1.Text.Length < 14)
                label5.Text = "يجب ان يكون الرقم القومي مكون من 14 رقم";
          else  if (textBox2.Text == "")
                label5.Text = "ادخل الرقم السري اولا";
            else if(textBox2.Text.Length<8)
                label5.Text = "يجب ان يكون الرقم السري مكون من 8 حروف علي الاقل";
            else if (textBox3.Text!=textBox2.Text)
                label5.Text = "يجب ان يكون الرقم السري متتطابق";
            else
            {
                bool exist = false;
                try
                {
                    query = "select count(*) from admin where ssn='" + textBox1.Text + "';";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();                   
                    while (datareader.Read())
                    {
                        exist = (datareader["count(*)"].ToString() == "1" ? true : false);
                    }
                    d.closeconnection();
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if(exist)
                {
                    label5.Text = "الرقم القومي موجود من قبل";
                }
                else
                {
                    try
                    {
                        query = $"insert into admin values ('{textBox1.Text}','{textBox2.Text}');";
                        d.openconnection();
                        cmd = new MySqlCommand(query, d.connection);
                        cmd.ExecuteNonQuery();
                        d.closeconnection();
                        MessageBox.Show("تمت الاضافة بنجاح");
                    }catch(MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
