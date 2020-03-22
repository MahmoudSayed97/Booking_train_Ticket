using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class addTrains : Form
    {
        public addTrains()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text == "")
                label5.Text = "ادخل رقم القطار اولا";
            else if (textBox2.Text == "")
                label5.Text = "اختر نوع القطار";
            else if (textBox1.Text == "")
                label5.Text = "اختر محطة قيام القطار";
            else
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
