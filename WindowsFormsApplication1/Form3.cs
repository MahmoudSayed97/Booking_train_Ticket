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
    public partial class Form3 : Form
    {
      public static bool login = false;
        public Form3()
        {
            InitializeComponent();
        }
        DP d = new DP();
        string query;MySqlCommand cmd;MySqlDataReader datareader;
        private void button1_Click(object sender, EventArgs e)
        {
            bool b=true;
            if (textBox1.Text.Length == 0)
            {
                label3.Text = "من فضلك ادخل الرقم القومي"; b = false;
            }
            else if (textBox1.Text.Length < 14)
            {
                label3.Text = "يجب ان يكون الرقم القومي مكون من 14 رقم"; b = false;
            }
            else if(textBox2.Text.Length==0)
            {
                label3.Text = "ادخل كلمة السر";b = false;
            }
            if(b)
            {
                try
                {
                    query = "select count(*) from admin where ssn='" + textBox1.Text + "' and pass='" + textBox2.Text + "';";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                    bool admin = false;
                    while (datareader.Read())
                    {
                        admin = (datareader["count(*)"].ToString() == "1" ? true : false);
                    }
                    d.closeconnection();
                    if (admin)
                    {
                        AdminForm ad = new AdminForm();
                        this.Visible = false;
                        ad.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        query = "select count(pass),pass from person where ssn='" + textBox1.Text + "';";
                        d.openconnection();
                        cmd = new MySqlCommand(query, d.connection);
                        datareader = cmd.ExecuteReader();
                        string s = "", cnt = "";
                        while (datareader.Read())
                        {
                            cnt = datareader["count(pass)"].ToString();
                            if (cnt != "0")
                                s = datareader["pass"].ToString();
                        }
                        d.closeconnection();
                        if (cnt == "0")
                        {
                            label3.Text = "الرقم القومي غير مسجل من قبل";
                        }
                        else if (s != textBox2.Text)
                        {
                            label3.Text = "كلمة السر غير صحيحة";
                        }
                        else
                        {
                            Form1.ssn_p = textBox1.Text;
                            login = true;
                            this.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
