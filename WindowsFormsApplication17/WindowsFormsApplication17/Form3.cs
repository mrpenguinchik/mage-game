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
    public partial class Form3 : Form
    {
        bool victory1;
        int vded1;
        public Form3(bool victory,int vded)
        {
            InitializeComponent();
            victory1 = victory;
            vded1 = vded;
            this.WindowState = FormWindowState.Maximized;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Height = this.Height - 50;
            textBox1.Width = this.Width - 50;
            if (victory1)
            {
                textBox1.Text = "Молодому чародею удалось одолеть саму Смерть! Он изгнал дух забвения из подземелья и заполучил заветный Посох Небес.\r\nКоличество врагов павших на вашем славном пути равно " + vded1.ToString();
            }
            else {

                textBox1.Text = "Увы, Смерть оказалось сильнее. Посох Небес так и останется в глубоких копях, и сама Смерть сторожит его.\r\nКоличество врагов с которыми вы еле справились равно " + vded1.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
