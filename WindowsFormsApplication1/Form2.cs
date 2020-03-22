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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DP d = new DP();
        string query;MySqlCommand cmd;MySqlDataReader datareader;public static bool register = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "الرقم القومي";
            label2.Text = "رقم حساب الفيزا";
            label3.Text = "كلمة السر";
            label4.Text = "تأكيد كلمة السر";
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void close(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;   
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = label6.Text = label7.Text = label8.Text = "";bool b = true;
            if(textBox1.Text.Length==0)
            {
                label5.Text = "من فضلك ادخل الرقم القومي";b = false;
            }
            else if (textBox1.Text.Length < 14)
            {
                label5.Text = "يجب ان يكون الرقم القومي مكون من 14 رقم"; b = false;
            }
            if (textBox2.Text.Length == 0)
            {
                label6.Text = "من فضلك ادخل رقم حساب الفيزا"; b = false;
            }
            else if (textBox2.Text.Length < 16)
            {
                label6.Text = "يجب ان يكون حساب الفيزا مكون من 16 رقم"; b = false;
            }
            if(textBox3.Text.Length<8)
            {
                label7.Text = "من فضلك ادخل 8 حروف علي الاقل"; b = false;
            }
           else if(textBox4.Text!=textBox3.Text)
            {
                label8.Text = "يجب ان تكون كلمتا السر متطابقتان"; b = false;
            }
            if(b)
            {
                bool c = true;
                try
                {
                    query = "select count(*) from bank where credit='" + textBox2.Text + "';";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                    string cr = "";
                    while(datareader.Read())
                    {
                        cr = datareader["count(*)"].ToString();
                    }
                    if(cr=="0")
                    {
                        c = false;
                        label6.Text = "هذا الحساب غير موجود";
                    }
                    d.closeconnection();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if(c)
                {
                    try
                    {
                         bool valid = true;
                        query = "select count(ssn) from person where ssn='" + textBox1.Text + "';";
                        d.openconnection();
                        cmd = new MySqlCommand(query, d.connection);
                        datareader = cmd.ExecuteReader();
                        string s = "";
                        while (datareader.Read())
                        {
                            s=datareader["count(ssn)"].ToString();
                        }
                        if (s!="0")
                        {
                            label5.Text = "الرقم القومي مسجل من قبل";
                            valid = false;
                        }
                        d.closeconnection();
                        d.openconnection();
                        query = "select count(credit) from person where credit='" + textBox2.Text + "';";
                        cmd = new MySqlCommand(query, d.connection);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            s=datareader["count(credit)"].ToString();
                        }
                        if (s != "0")
                        {
                            label6.Text = "رقم الفيزا موجود من قبل";
                            valid = false;
                        }
                        d.closeconnection();
                        if (valid)
                        {
                            d.openconnection();
                            query = "insert into person(ssn,credit,pass) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');";
                            cmd = new MySqlCommand(query, d.connection);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("تم التسجيل بنجاح");
                            Form1.ssn_p = textBox1.Text;Form1.credit_c = textBox2.Text;
                            register = true;
                            d.closeconnection();
                            this.Close();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
                textBox3.UseSystemPasswordChar = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
