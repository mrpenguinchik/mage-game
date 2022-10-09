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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        { label1.Text="инструкции";
        textBox1.Text = "WASD-Движение в Верх,Лево,Низ,Право соответственно\r\nQ-замедление\r\nShift-Ускорение\r\nEsc-смена посоха\r\nM-отображение карты\r\nНажатие по врагу на экране-атака по нему\r\nЛегеда карты:\r\nЗеленая точка-игрок\r\nКрасные точки- враги\r\nЗолотые точки-сундуки\r\nБелая точка-выход\r\nПрозрачная точка-Босс";
   
        }
    }
}
