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
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }
        DP d = new DP();MySqlCommand cmd;
        private void Ticket_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            src.Text = Form1.src;
            dest.Text = Form1.dest;
            string []s = Form1.time.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            price.Text = s[0];
            T_class.Text = Form1.ty;
            ch_num.Text = (((int)r.NextDouble()) % 10 + 1).ToString();
            T_num.Text = s[3];
            date.Text = booking.date;
            src_time.Text = s[1];
            dest_time.Text = s[2];
            try
            {

            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
