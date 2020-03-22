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
    public partial class modifySchedual : Form
    {
        DP d = new DP();string query;MySqlCommand cmd;MySqlDataReader datareader;
        public modifySchedual()
        {
            InitializeComponent();
            try
            {
                query = "select ty from train_type;";
                d.openconnection();
                cmd = new MySqlCommand(query, d.connection);
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    comboBox1.Items.Add(datareader["ty"].ToString());
                }
                d.closeconnection();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                query = "select station from stations;";
                d.openconnection();
                cmd = new MySqlCommand(query, d.connection);
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    comboBox2.Items.Add(datareader["station"].ToString());
                    comboBox3.Items.Add(datareader["station"].ToString());
                }
                d.closeconnection();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text == "")
                label5.Text = "ادخل رقم القطار اولا";
            else if (comboBox1.SelectedIndex == -1)
                label5.Text = "اختر نوع القطار";
            else if (comboBox2.SelectedIndex == -1)
                label5.Text = "اختر محطة قيام القطار";
            else if (comboBox3.SelectedIndex == -1)
                label5.Text = "اختر محطة وصول القطار";
            else if (textBox2.Text.Length == 0)
                label5.Text = "ادخل وقت القيام";
            else if (textBox3.Text.Length == 0)
                label5.Text = "ادخل وقت الوصول";
            else if (comboBox2.SelectedItem == comboBox3.SelectedItem)
                label5.Text = "لا يمكن ان تكون محطة الوصول هي نفسها محطة القيام";
            else
            {
                bool exist = true;
                try
                {
                    query = "select count(*) from train where ssn=" + textBox1.Text + ",ty='" + comboBox1.SelectedItem + "';";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                    
                    while (datareader.Read())
                    {
                        exist = (datareader["count(*)"].ToString() == "0" ? false : true);
                    }
                    d.closeconnection();
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if(exist==false)
                {
                    label5.Text = "رقم القطار غير موجود";
                }
                else
                {
                    try
                    {
                        query = "update schedaul set time_src='" + textBox2.Text + "',time_dist='" + textBox3.Text + "' where ssn_train='" + textBox1.Text + "' and source_s='" + comboBox2.SelectedItem + "' and destination_s='" + comboBox3.Text + "';";
                        d.openconnection();
                        cmd = new MySqlCommand(query, d.connection);
                        cmd.ExecuteNonQuery();
                        d.closeconnection();
                        MessageBox.Show("تم التعديل بنجاح");
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 2)
                textBox2.AppendText(":");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 2)
                textBox3.AppendText(":");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
