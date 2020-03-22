namespace WindowsFormsApplication1
{
    partial class Ticket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_8 = new System.Windows.Forms.Label();
            this.src = new System.Windows.Forms.Label();
            this.dest = new System.Windows.Forms.Label();
            this.T_class = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.T_num = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.src_time = new System.Windows.Forms.Label();
            this.dest_time = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ch_num = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Train Class :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(303, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Train_Num :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Price :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(307, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date :";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(296, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 26);
            this.label7.TabIndex = 12;
            this.label7.Text = "source time :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label_8
            // 
            this.label_8.Location = new System.Drawing.Point(286, 98);
            this.label_8.Name = "label_8";
            this.label_8.Size = new System.Drawing.Size(86, 26);
            this.label_8.TabIndex = 13;
            this.label_8.Text = "destination time :";
            // 
            // src
            // 
            this.src.Location = new System.Drawing.Point(91, 9);
            this.src.Name = "src";
            this.src.Size = new System.Drawing.Size(124, 25);
            this.src.TabIndex = 14;
            // 
            // dest
            // 
            this.dest.Location = new System.Drawing.Point(110, 35);
            this.dest.Name = "dest";
            this.dest.Size = new System.Drawing.Size(124, 26);
            this.dest.TabIndex = 15;
            // 
            // T_class
            // 
            this.T_class.Location = new System.Drawing.Point(110, 61);
            this.T_class.Name = "T_class";
            this.T_class.Size = new System.Drawing.Size(124, 26);
            this.T_class.TabIndex = 16;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(91, 87);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(124, 26);
            this.price.TabIndex = 17;
            // 
            // T_num
            // 
            this.T_num.Location = new System.Drawing.Point(375, 9);
            this.T_num.Name = "T_num";
            this.T_num.Size = new System.Drawing.Size(124, 15);
            this.T_num.TabIndex = 18;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(354, 45);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(145, 16);
            this.date.TabIndex = 19;
            // 
            // src_time
            // 
            this.src_time.Location = new System.Drawing.Point(379, 72);
            this.src_time.Name = "src_time";
            this.src_time.Size = new System.Drawing.Size(120, 26);
            this.src_time.TabIndex = 20;
            // 
            // dest_time
            // 
            this.dest_time.Location = new System.Drawing.Point(379, 98);
            this.dest_time.Name = "dest_time";
            this.dest_time.Size = new System.Drawing.Size(124, 26);
            this.dest_time.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(402, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 37);
            this.button1.TabIndex = 24;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(91, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "chair number:";
            // 
            // ch_num
            // 
            this.ch_num.Location = new System.Drawing.Point(197, 127);
            this.ch_num.Name = "ch_num";
            this.ch_num.Size = new System.Drawing.Size(100, 23);
            this.ch_num.TabIndex = 26;
            // 
            // Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(511, 206);
            this.Controls.Add(this.ch_num);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dest_time);
            this.Controls.Add(this.src_time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.T_num);
            this.Controls.Add(this.price);
            this.Controls.Add(this.T_class);
            this.Controls.Add(this.dest);
            this.Controls.Add(this.src);
            this.Controls.Add(this.label_8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ticket";
            this.Load += new System.EventHandler(this.Ticket_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_8;
        private System.Windows.Forms.Label src;
        private System.Windows.Forms.Label dest;
        private System.Windows.Forms.Label T_class;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label T_num;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label src_time;
        private System.Windows.Forms.Label dest_time;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ch_num;
    }
}