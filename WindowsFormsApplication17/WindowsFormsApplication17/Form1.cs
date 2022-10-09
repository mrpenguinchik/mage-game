using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string nickname;
            Form2 f2 = new Form2();
            
            // nickname = textBox1.Text;
            Hide();
           
            f2.ShowDialog();

            bool victory = f2.victory1;
             int vded = f2.vded;
             Hide();
            Form3 f3 = new Form3(victory,vded);
            f3.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
