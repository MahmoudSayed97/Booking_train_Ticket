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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeTrains re = new removeTrains();
            re.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addTrains a = new addTrains();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            modifySchedual m = new modifySchedual();
            m.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addAdmin adm = new addAdmin();
            adm.ShowDialog();
        }
    }
}
