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
    public partial class booking : Form
    {
        public booking()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
        }
        DP d = new DP();
        public static string pass = "",date="";string query;MySqlCommand cmd;MySqlDataReader datareader;
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            string pass = "", money_c = "";
            
            try
                {
                d.openconnection();
                query = "select pass,money from bank where credit='" + Form1.credit_c + "';";
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    pass = datareader["pass"].ToString();
                    money_c = datareader["money"].ToString();
                }
                d.closeconnection();
                if (pass != textBox1.Text)
                {
                    label2.Text = "الرقم السري غير صحيح";
                }
                else
                {
                    double money = double.Parse(money_c);
                    if (MessageBox.Show("هل تريد تأكيد عملية الحجز", "تأكيد عملية الحجز", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (money >= double.Parse(Form1.cost))
                        {

                            money -= double.Parse(Form1.cost);
                            query = $"update bank set money={money} where credit='" + Form1.credit_c + "';";
                            d.openconnection();
                            cmd = new MySqlCommand(query, d.connection);
                            cmd.ExecuteNonQuery();
                            d.closeconnection();
                            date = dateTimePicker1.Text;
                            Ticket t = new Ticket();
                            this.Visible = false;
                            for (int i=0;i<int.Parse(Form1.ch_num);i++)
                            {
                                
                                t.ShowDialog();
                                
                            }
                            this.Visible = true;
                        }
                        else
                        {
                            label2.Text = "عفوا رصيدكم الجالي لا يكفي لاتمام عملية الحجز";
                        }
                    }
                }
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //this.Close();
        }
    }
}
