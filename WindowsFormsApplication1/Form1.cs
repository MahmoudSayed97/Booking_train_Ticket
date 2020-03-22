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
    public partial class Form1 : Form
    {
        public static string ssn_p = "",credit_c="",cost="",src="",dest="",ty="",time="",ch_num="";
        Random r;
        ListBox lst2 = new ListBox();
        ListBox lst3 = new ListBox();
        ListBox lst4 = new ListBox();
        public Form1()
        {
            InitializeComponent();
            label6.Text="القطار  الوصول  القيام السعر";
            label6.Font = new Font(FontFamily.GenericMonospace, label6.Font.Size);
            try
            {
                d.openconnection();
                query = "set sql_safe_updates=0;";
                cmd = new MySqlCommand(query, d.connection);
                cmd.ExecuteNonQuery();
                d.closeconnection();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DP d = new DP();MySqlCommand cmd;MySqlDataReader datareader;string query;List<string> st = new List<string>();
        bool btn = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            try
            {
                query = "select *from stations;";
                d.openconnection();
                cmd = new MySqlCommand(query, d.connection);
                datareader = cmd.ExecuteReader();
                while(datareader.Read())
                {
                    st.Add(datareader["station"].ToString());
                }
                foreach(var x in st)
                {
                    lst2.Items.Add(x);
                    lst3.Items.Add(x);
                }
                d.closeconnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                query = "select *from train_type";
                d.openconnection();
                cmd = new MySqlCommand(query, d.connection);
                datareader = cmd.ExecuteReader();
                while(datareader.Read())
                {
                    lst4.Items.Add(datareader["ty"].ToString());
                }
                d.closeconnection();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (var x in lst2.Items) listBox2.Items.Add(x);
            foreach (var x in lst3.Items) listBox3.Items.Add(x);
            foreach (var x in lst4.Items) listBox4.Items.Add(x);
        }
       private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            if(Form2.register==true)
            {
                button1.Visible = button2.Visible = false;
                button4.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Visible = false;
            f3.ShowDialog();
            this.Visible = true;
            if(Form3.login == true)
            {
                button1.Visible = false;button2.Visible = false;button4.Visible = true;
                try
                {
                    query = "select credit from person where ssn='" + ssn_p + "';";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                    while(datareader.Read())
                    {
                        credit_c = datareader["credit"].ToString();
                    }
                    d.closeconnection();
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2.register = false;
            Form3.login = false;
            button4.Visible = false;
            button1.Visible = true;button2.Visible = true;
            ssn_p = ""; credit_c = ""; cost = ""; src = ""; dest = ""; ty = ""; time = ""; ch_num = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btn = true;
            listBox1.Items.Clear();
            label4.Text = "";bool v= true;
            if (listBox2.Items.Count!=1||listBox2.Items[0].ToString()!=textBox1.Text)
            {
                label4.Text = "محطة قيام غير موجودة";v = false;
            }
            else if(listBox3.Items.Count!=1 || listBox3.Items[0].ToString()!= textBox2.Text)
            {
                label4.Text = "محطة وصول غير موجودة";v = false;
            }
            else if(listBox4.Items.Count!=1 || listBox4.Items[0].ToString()!= textBox3.Text)
            {
                label4.Text = "نوع قطار غير موجود";v = false;
            }
            else if(textBox1.Text==textBox2.Text)
            {
                v = false;label4.Text = "لا يمكن ان يكون محطة الوصول هي نفسها محطة القيام";
            }
            if(v)
            {
                try
                {
                    query = "select time_src,time_dist,ssn_train,price from schedual where source_s='"+textBox1.Text+"' and destination_s='"+textBox2.Text+"' and ssn_train in( select ssn from train where ty='"+textBox3.Text+"');";
                    d.openconnection();
                    cmd = new MySqlCommand(query, d.connection);
                    datareader = cmd.ExecuteReader();
                    while(datareader.Read())
                    {
                        listBox1.Items.Add(" "+datareader["price"] + "         " + datareader["time_src"].ToString() + "           " + datareader["time_dist"].ToString() + "           " + datareader["ssn_train"].ToString() + Environment.NewLine);
                    }
                    d.closeconnection();
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListBox c = new ListBox();
            string s = textBox1.Text;
            foreach (string t in lst2.Items)
            {
                if (t.Length < s.Length) continue;
                bool b = true;
                if (t.Substring(0, s.Length).Equals(s))
                    c.Items.Add(t);
            }
            listBox2.Items.Clear();
            foreach (string t in c.Items)
                listBox2.Items.Add(t);
            btn = false;
            listBox1.Items.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ListBox c = new ListBox();
            string s = textBox2.Text;
            foreach (string t in lst3.Items)
            {
                if (t.Length < s.Length) continue;
                bool b = true;
                if (t.Substring(0, s.Length)==s)
                    c.Items.Add(t);
            }
            listBox3.Items.Clear();
            foreach (string t in c.Items)
                listBox3.Items.Add(t);
            btn = false;
            listBox1.Items.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ListBox c = new ListBox();
            string s = textBox3.Text;
            foreach (string t in lst4.Items)
            {
                if (t.Length < s.Length) continue;
                bool b = true;
                if (t.Substring(0, s.Length).Equals(s))
                    c.Items.Add(t);
            }
            listBox4.Items.Clear();
            foreach (string t in c.Items)
                listBox4.Items.Add(t);
            btn = false;
            listBox1.Items.Clear();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                textBox1.Text = "";
            else textBox1.Text = listBox2.SelectedItem.ToString();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1)
                textBox2.Text = "";
            else textBox2.Text = listBox3.SelectedItem.ToString();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == -1)
                textBox3.Text = "";
            else textBox3.Text = listBox4.SelectedItem.ToString();
        }
        bool bo = true;
        int x,ind;
        private void book_Click(object sender, EventArgs e)
        {      
            label4.Text = "";
            if(btn==false)
            {
                label4.Text = "اعرض المواعيد المناسبة اولا";
            }
            else
            {
                if (listBox1.SelectedIndex == -1)
                    label4.Text = "اختر الميعاد ";
                else if (listBox5.SelectedIndex == -1)
                    label4.Text = "من فضلك اختر عدد التذاكر";
                else 
                {
                    if (listBox1.SelectedIndex != ind && listBox1.SelectedIndex != -1)
                        bo = true;
                    if (bo)
                    {
                        r = new Random();
                        double f = r.NextDouble();
                        f *= 10;
                        x = (int)(f);
                    }
                    if (button2.Visible == true) MessageBox.Show("you have to login");
                    else if (int.Parse(listBox5.SelectedItem.ToString())>x)
                    {
                        label4.Text = $"عفوا لا يوجد عدد {listBox5.SelectedItem} مقعد متاح في هذا الميعاد";
                        bo = false;
                        ind = listBox1.SelectedIndex;
                    }
                    else
                    {
                        src = textBox1.Text;dest = textBox2.Text;ty = textBox3.Text;time = listBox1.SelectedItem.ToString();ch_num = listBox5.SelectedItem.ToString();
                        booking b = new booking();
                        this.Visible = false;
                        string []s =listBox1.SelectedItem.ToString().Split(new char[]{ ' ', ' ' },StringSplitOptions.RemoveEmptyEntries);
                        cost = (double.Parse(s[0]) * double.Parse(listBox5.SelectedItem.ToString())).ToString();
                        b.ShowDialog();
                        this.Visible = true;
                    }
                    
                }
            }
        }
    }
}
