using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication17
{
    public partial class Form2 : Form
    {
        class item {
            public string type1 { get; set; }
           public int damage { get; set; }
           public Bitmap pic { get; set;}
           public Bitmap  effect{ get; set; }
           public int type{get; set;}
           public int area { get; set; }
           public int timeonv { get; set; }
                public int timeonm{get; set;}
           
            public item(Random r, int level,int hd1,int hd2) { damage = r.Next(1, 20) * level; type = r.Next(1, 4); switch (type) {
                case 1: pic = new Bitmap(Properties.Resources.stuff1, 5 * hd1, 5 * hd2); effect=new Bitmap(Properties.Resources.acidexp, 5 * hd1, 5 * hd2); type1 = "яда"; area = 0; timeonm = 2; timeonv = r.Next(6, 15); break;
                case 2: pic = new Bitmap(Properties.Resources.stuff2, 5 * hd1, 5 * hd2); effect=new Bitmap(Properties.Resources.iceexp, 5 * hd1, 5 * hd2); type1 = "льда"; area = 1; timeonm = 3; timeonv = r.Next(1, 3); break;
                case 3: pic = new Bitmap(Properties.Resources.stuff3, 5 * hd1, 5 * hd2); effect=new Bitmap(Properties.Resources.fireexp, 5 * hd1, 5 * hd2);  type1 = "огня"; area = r.Next(1, 3); timeonm = 5; timeonv = 1; break;
            } }
            public void ressize(int hd1, int hd2)
            {
                switch (type)
                {
                    case 1: pic = new Bitmap(Properties.Resources.stuff1, 5 * hd1, 5 * hd2); effect = new Bitmap(Properties.Resources.acidexp, 5 * hd1, 5 * hd2); break;
                    case 2: pic = new Bitmap(Properties.Resources.stuff2, 5 * hd1, 5 * hd2); effect = new Bitmap(Properties.Resources.iceexp, 5 * hd1, 5 * hd2); break;
                    case 3: pic = new Bitmap(Properties.Resources.stuff3, 5 * hd1, 5 * hd2); effect = new Bitmap(Properties.Resources.fireexp, 5 * hd1, 5 * hd2); break;
                }
            }


        }                          
        class player               
        {
            public player(int x1, int y1) { x = x1; y = y1; level = 0; hp = 100; Random r = new Random(); }
            public int x { get; set; }
            public int y { get; set; }
            public item w1{get; set;}
            public int maxhp { get; set; }
            public item w2 { get; set; }
            public float movex { get; set; }
            public int level { get; set; }
            public float movey { get; set; }

            public int score { get; set; }

            public int hp { get; set; }

            public int mp { get; set; }

            public int rnum { get; set; }

            public void move(int x, int y,ref char[,] map,ref bool chestfind, ref bool findexit)
            {
                char z;
                if (this.x + x < map.GetLength(1) && this.x + x >= 0 && map[this.y, this.x + x] != '*' && map[this.y, this.x + x] != 'v')
                {
                    if (map[this.y, this.x + x] == 'c')
                    {
                        map[this.y, this.x + x] = '#';
                        chestfind = true;
                    }
                    if (map[this.y, this.x + x] == 'e')
                    {
                        map[this.y, this.x + x] = '#';
                        findexit = true;
                    }
                    map[this.y, this.x] = '#';

                    map[this.y, this.x + x] = 'p';
                    this.x += x;



                }
                if (this.y + y < map.GetLength(0) && this.y + y >= 0 && map[this.y + y, this.x] != '*' && map[this.y + y, this.x] != 'v')
                {
                    if (map[this.y + y, this.x] == 'c')
                    {
                        map[this.y + y, this.x] = '#';
                        chestfind = true;

                    }
                    if (map[this.y + y, this.x] == 'e')
                    {
                        map[this.y + y, this.x] = '#';
                        findexit = true;
                    }
                    map[this.y, this.x] = '#';
                    map[this.y + y, this.x] = 'p';
                    this.y += y;



                }

            }

        }
        class room {
          public  int x;
          public int y;
          public int x1;
          public int y1;
          public int rnum;
          
          public void gen(int aboba, Random r) { x = r.Next(1, aboba); x1 = r.Next(x, x + 10) + 10; if (x1 > aboba) { x1 = aboba - 1; } y = r.Next(1, aboba); y1 = r.Next(y, y + 10) + 10; if (y1 > aboba) { y1 = aboba - 1; } }
          public room(int aboba, Random r) { x = r.Next(1, aboba); x1 = r.Next(x, x + 10)+10; if (x1 >= aboba) { x1 = aboba - 1; } y = r.Next(1, aboba); y1 = r.Next(y, y + 10)+10; if (y1 >= aboba) { y1 = aboba - 1; } }
        }
        class vrag
        {
            public int x{get;set;}
            public int y{get;set;}
            public int damage { get; set; }
            public int hp { get; set; }
            public bool dead { get; set; }
            public bool deleted { get; set; }
            public int rnum { get; set; }
            public int timeonv { get; set; }
            public int size { get; set; }
            public int damageon { get; set; }
            public bool boss { get; set; }
            public void damaged() { if (timeonv > 0) { hp -= damageon; timeonv--; } if (hp <= 0) { dead = true;  } }
            public vrag(int x, int y, int rnum, int level, Random r) { hp = r.Next(70 * level, 100 * level); damage = r.Next(1 * level, 6 * level); this.x = x; this.y = y; dead = false; this.rnum = rnum; this.size = 0; boss = false; }
            public void vmove(int i, ref char[,] map,ref player p, ref bool pdmg,ref bool vmov,ref int vded,ref bool endgame)
            {
                if (!this.dead)
                {
                    if (vmov)
                    {
                        char z; int x1, y1;

                        if (p.x < this.x) { x1 = -1; } else { x1 = 1; }
                        if (p.y < this.y) { y1 = -1; } else { y1 = 1; }

                        if (this.y - y1 < 0 || this.y - y1 > map.GetLength(0) || map[this.y + y1, this.x] != '#')
                        {
                            if (map[this.y + y1, this.x] == 'p' && !pdmg) { p.hp -= this.damage; pdmg = true; if (p.hp <= 0) { endgame = true; } }
                        }
                        else
                        {
                            map[this.y, this.x] = '#'; if (!this.boss) { map[this.y + y1, this.x] = 'v'; } else { map[this.y + y1, this.x] = 'b'; } this.y += y1;
                        };
                        if (this.x - x1 < 0 || this.x - x1 > map.GetLength(0) || map[this.y, this.x + x1] != '#')
                        {
                            if (map[this.y, this.x + x1] == 'p' && !pdmg) { p.hp -= this.damage; pdmg = true; if (p.hp <= 0) { endgame = true; } }
                        }
                        else
                        {
                            map[this.y, this.x] = '#'; if (!this.boss) { map[this.y, this.x + x1] = 'v'; } else { map[this.y, this.x + x1] = 'b'; } this.x += x1;
                        };
                    }

                }
                else { if (!this.deleted) { this.deleted = true; map[this.y, this.x] = '#'; vded++; } }
                pdmg = false;



            }
     
        }
        
        BufferedGraphicsContext con = BufferedGraphicsManager.Current;
        BufferedGraphics bg;
        player p;
        List<vrag> vragi = new List<vrag>();
        Pen a = new Pen(Color.Black, 1);
        Pen b = new Pen(Color.Green, 1);
        Pen c = new Pen(Color.Red, 1);
        Pen d = new Pen(Color.White, 1);
        Pen e = new Pen(Color.Yellow, 1);
    
        char[,] map;
        public int vded=0;
        List<room> rooms=new List<room>();
        public Form2()
        {

            InitializeComponent();

        }
        string line, l;
        public void pmov(bool[] down)
        {
            int x = 0, y = 0;

            if (down[0])
            {
                y = -1;
            }
            if (down[1])
            {
                y = 1;
            }
            if (down[2])
            {
                x = -1;

            }
            if (down[3])
            {
                x = 1;
            }
            if (x != 0 || y != 0)
            {
                bool chestfind, findexit;
                chestfind = false;
                findexit = false;
                p.move(x, y,ref map,ref chestfind,ref findexit);
                if (chestfind) { openchest(); }
                if (findexit) { exiting(); }
            }
        }
        public bool pdmg = false;
       
       
        item newitem;
        bool chest1,exiting1;
        int chesttype;
        public void openchest() {
            Random r=new Random();
            chesttype = r.Next(0, 2);
            timer1.Stop();
            label1.Visible = !label1.Visible;
                label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label1.Enabled = !label1.Enabled;
            label2.Enabled = !label2.Enabled;
            label3.Enabled = !label3.Enabled;
            if (chesttype == 0)
            {
                newitem = new item(r, p.level, hd1, hd2);
                label3.Text = "Вы нашли посох! " + newitem.type1 + " Взять?";
            }
            else
            {
                label3.Text = "Вы нашли зелье здоровья! Выпить?";
            }
                chest1 = true;
            
        }
     public   void exiting() { timer1.Stop();
            label1.Visible = !label1.Visible;
                label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label1.Enabled = !label1.Enabled;
            label2.Enabled = !label2.Enabled;
            label3.Enabled = !label3.Enabled;
            if (p.level != 5)
            {
                label3.Text = "Вы нашли спуск! Спустится?";
            }
            else
            {
                label3.Text = "Вы нашли Небесный посох? Взять?";
            }
            exiting1=true; 
     }
        void mapload()
     {
      
             int x = 0;
             p.level++;
             p.maxhp = p.level * 100;
             rooms.Clear();
             vragi.Clear();
             map = null;
             Random r = new Random();
             x = r.Next(150, 300);
             map = new char[x, x];

             for (int i = 0; i < x; i++)
             {
                 for (int j = 0; j < x; j++)
                 {
                     map[i, j] = '*';
                 }
             }


             for (int i = 0; i < r.Next(8, 15); i++)
             {
                 rooms.Add(new room(x, r));
                 rooms[i].rnum = i;

             }

             int z1 = 0;
             foreach (room room in rooms)
             {
                 for (int i = room.y; i < room.y1; i++)
                 {
                     for (int j = room.x; j < room.x1; j++)
                     {
                         map[i, j] = '#';
                     }
                 }


             }
             int x1, x2, y1, y2, c;

             for (int i = 0; i < rooms.Count - 1; i++)
             {
                 x1 = rooms[i].x;
                 x2 = rooms[i + 1].x1;
                 if (x1 > x2)
                 {
                     c = x1;
                     x1 = x2;
                     x2 = c;
                 }
                 y1 = rooms[i].y;
                 y2 = rooms[i + 1].y1;

                 for (int j = x1; j <= x2; j++)
                 {
                     map[y2, j] = '#';

                     if (y2 - 1 > 0)
                     {

                         map[y2 - 1, j] = '#';
                     }
                     if (y2 - 2 > 0)
                     {
                         map[y2 - 2, j] = '#';
                     }
                 }
                 x1 = rooms[i].x;
                 x2 = rooms[i + 1].x1;
                 if (y1 > y2)
                 {
                     c = y1;
                     y1 = y2;
                     y2 = c;
                 }
                 for (int j = y1; j <= y2; j++)
                 {
                     map[j, x1] = '#';

                     if (x1 - 1 > 0)
                     {

                         map[j, x1 - 1] = '#';
                     }
                     if (x1 - 2 > x)
                     {
                         map[j, x1 - 2] = '#';
                     }
                 }


             }
             for (int i = 0; i < x; i++)
             {
                 for (int j = 0; j < x; j++)
                 {
                     if (i == 0 || j == 0 || i == x - 1 || j == x - 1) { map[i, j] = '*'; }
                 }
             }
             Random r1 = new Random();
             bool ppos = true;
             int z, y;
             while (ppos)
             {
                 z = r.Next(1, x - 2);
                 y = r1.Next(1, x - 2);
                 if (map[z, y] == '#')
                 {
                     map[z, y] = 'p';
                     p.x = y;
                     p.y = z;
                     ppos = false;

                 }
             }
             for (int i = 0; i < rooms.Count; i++)
             {
                 z = r.Next(rooms[i].x, rooms[i].x1);
                 y = r1.Next(rooms[i].y, rooms[i].y1);
                 if (map[y, z] != 'p')
                 {
                     map[y, z] = 'c';
                 }
             }
             for (int i = 0; i < rooms.Count; i++)
             {
                 for (int j = 0; j < r.Next(1, 3) + p.level; j++)
                 {
                     z = r.Next(rooms[i].x, rooms[i].x1);
                     y = r1.Next(rooms[i].y, rooms[i].y1);
                     if (map[y, z] != 'p' && map[y, z] != 'c')
                     {
                         map[y, z] = 'v';
                         vragi.Add(new vrag(z, y, i, p.level, r));
                     }



                 }
             }
             z = r.Next(0, rooms.Count);
             int xm;
             bool exitgen = true;
             int i1 = 0;
             while (z != vragi[i1].rnum) {
                 i1++;
             }
            vragi[i1].hp *= 10;
            vragi[i1].damage *= 3;
            vragi[i1].size = 1;
            vragi[i1].boss = true;
            map[vragi[i1].y, vragi[i1].x] = 'b';
             while (exitgen)
             {
                 xm = r.Next(rooms[z].x, rooms[z].x1);
                 y = r1.Next(rooms[z].y, rooms[z].y1);
                 if (map[y, xm] == '#')
                 {
                     map[y, xm] = 'e';
                     ey = y;
                     ex = xm;
                     exitgen = false;
                 }
              
             }
       
             p.rnum = 99;
             string k = string.Concat(Application.StartupPath, "\\map.txt");

             using (StreamWriter sr = new StreamWriter(k, false, System.Text.Encoding.Default))
             {
                 for (int i = 0; i < x; i++)
                 {
                     line = " ";
                     for (int j = 0; j < x; j++)
                     {
                         line = line + map[i, j];
                     }
                     if (line != " ")
                     {
                         sr.WriteLine(line);
                     }
                 }
             }

             timer1.Start();
        
        }
      
        int hd1, hd2;
        bool endgame1;
        private void Form2_Load(object sender, EventArgs e)
        {
          
       vrag1=new Bitmap[5];
       boss = new Bitmap[5];
            Graphics g = this.CreateGraphics();
            bg = con.Allocate(g, new Rectangle(0, 0, this.Width, this.Height));
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label1.Enabled = !label1.Enabled;
            label2.Enabled = !label2.Enabled;
            label3.Enabled = !label3.Enabled;
           
            hd1 = this.Width / 50;
            hd2 = this.Height / 50;


            
            
             p = new player(1, 1);
             Random r = new Random();
         
             mapload();
             p.w1 = new item(r, p.level, hd1, hd2); p.w2 = new item(r, p.level, hd1, hd2);
             sizechance();
             endgame1 = false;
             victory1 = false;
             this.WindowState = FormWindowState.Maximized;

        }
        int pymin;
        int pxmin;
        int pymax;
        int pxmax;
        int ex, ey;
        int timeonm;
        bool vmov = false;
        int x1, y1,x2,y2;
        public void game()
        {
            vmov = !vmov;
            pymin = -6 + p.y;
            pxmin = -5 + p.x;
            pymax = 6 + p.y;
            pxmax = 7 + p.x;

            if (pxmin < 0) { pxmin = 0; }

            if (pymin < 0) { pymin = 0; ; }

            if (pymax >= map.GetLength(0)) { pymax = map.GetLength(0); }
            if (pxmax >= map.GetLength(1)) { pxmax = map.GetLength(1); }
            pmov(down);
            label4.Text ="координаты "+ p.x.ToString() + " " + p.y.ToString();
            double x, y;
            bool any = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                if (p.x <= rooms[i].x1 && p.x >= rooms[i].x && p.y <= rooms[i].y1 && p.y >= rooms[i].y)
                {
                    p.rnum = rooms[i].rnum;
                    any = true;
                }
                else
                {
                    if (!any)
                    {
                        p.rnum = 99;
                    }
                }
            }
          
            for (int i = 0; i < vragi.Count;i++ )
            {
                if (vragi[i].rnum == p.rnum)
                {
                    vragi[i].vmove(i,ref map,ref p,ref pdmg,ref vmov,ref vded,ref endgame1);
                }
            }
            x = MousePosition.X-this.Width/2-this.Left;
            y = MousePosition.Y-this.Height/2-this.Top;
            
            x1=Convert.ToInt32(Math.Truncate((x/(5*hd1) ) +p.x));
            y1=Convert.ToInt32(Math.Truncate((y/(5*hd2)-0.4 )+p.y));
         
           label5.Text ="урон "+ p.w1.damage.ToString();
           if (timeonm > 0)
           {
               for(int i=0;i<vragi.Count;i++) {
                   if (vragi[i].x + vragi[i].size >= x1 - p.w1.area && vragi[i].x + vragi[i].size <= x1 + p.w1.area && vragi[i].y + vragi[i].size >= y1 - p.w1.area && vragi[i].y + vragi[i].size <= y1 + p.w1.area && vragi[i].x - vragi[i].size >= x1 - p.w1.area && vragi[i].x - vragi[i].size <= x1 + p.w1.area && vragi[i].y - vragi[i].size >= y1 - p.w1.area && vragi[i].y - vragi[i].size <= y1 + p.w1.area)
                   {
                   vragi[i].damageon = p.w1.damage; vragi[i].timeonv = p.w1.timeonv;
                   
               }
               }
               timeonm--;
           }
           foreach (vrag v in vragi) { v.damaged(); }
           label6.Text ="здоровье "+ p.hp.ToString();
           map[ey, ex] = 'e';
           map[p.y, p.x] = 'p';
           if (endgame1) { endgame();  }
           if (victory1) { endgame(); }

           double point = p.maxhp;
           point =Math.Abs( p.hp / point * 100);
           progressBar1.Value = (int)point ; 
        }
        bool m=true;
        void drawing(int pxmin,int pxmax,int pymin,int pymax){
          
                bg.Graphics.Clear(Color.White);
                bg.Graphics.DrawImage(floor, 0 * hd1, 0 * hd2);


                int areaxmin = -p.w1.area + x2;
                int areaxmax = p.w1.area + x2;
                int areaymin = -p.w1.area + y2;
                int areaymax = p.w1.area + y2;
                for (int i = pymin; i < pymax; i++)
                {

                    for (int j = pxmin; j < pxmax; j++)
                    {
                        switch (map[i, j])
                        {

                            case '*': bg.Graphics.DrawImage(wall, 25 * hd1 - ((p.x - j) * 5 * hd1), 25 * hd2 - ((p.y - i) * 5 * hd2)); break;


                            case 'c': bg.Graphics.DrawImage(chest, 25 * hd1 - ((p.x - j) * 5 * hd1), 25 * hd2 - ((p.y - i) * 5 * hd2)); break;


                            case 'v': bg.Graphics.DrawImage(vrag1[p.level - 1], 25 * hd1 - ((p.x - j) * 5 * hd1), 25 * hd2 - ((p.y - i) * 5 * hd2)); break;
                            case 'b': bg.Graphics.DrawImage(boss[p.level - 1], 25 * hd1 - ((p.x - j +1) * 5 * hd1), 25 * hd2 - ((p.y - i +1) * 5 * hd2));  break;
                        }
                        if (i == ey && j == ex)
                        {
                            if (p.level != 5)
                            {
                                bg.Graphics.DrawImage(exit, 25 * hd1 - ((p.x - j) * 5 * hd1), 25 * hd2 - ((p.y - i) * 5 * hd2));
                            }
                            else
                            {
                                bg.Graphics.DrawImage(exitv, 25 * hd1 - ((p.x - j) * 5 * hd1), 25 * hd2 - ((p.y - i) * 5 * hd2));
                            }
                        }
                    
              
                    }
                }
                if (m)
                {
                    double hd12, hd22;
                    hd12 = hd1;
                    hd22 = hd2;
                    int hd11, hd21;
                    hd11 = Convert.ToInt32(Math.Round(hd12 / 10));
                    hd21 = Convert.ToInt32(Math.Round(hd22 / 10));
                    for (int i1 = 0; i1 < map.GetLength(0); i1++)
                    {
                        for (int j1 = 0; j1 < map.GetLength(1); j1++)
                        {
                            switch (map[i1, j1]) {

                                case '#': bg.Graphics.FillRectangle(a.Brush, j1 * hd11, i1 * hd21, hd11, hd21); break;
                                case 'p': bg.Graphics.FillRectangle(b.Brush, j1 * hd11, i1 * hd21, hd11, hd21); break;
                                case 'v': bg.Graphics.FillRectangle(c.Brush, j1 * hd11, i1 * hd21, hd11, hd21); break;
                                case 'e': bg.Graphics.FillRectangle(d.Brush, j1 * hd11, i1 * hd21, hd11, hd21); break;
                                case 'c': bg.Graphics.FillRectangle(e.Brush, j1 * hd11, i1 * hd21, hd11, hd21); break;
                            }

                        }
                    }
                }
                bg.Graphics.DrawImage(mage, 25 * hd1, 25 * hd2);
                if (timeonm != 0)
                {
                    for (int i = areaymin; i <= areaymax; i++)
                    {

                        for (int j = areaxmin; j <= areaxmax; j++)
                        {

                            bg.Graphics.DrawImage(p.w1.effect, 25 * (hd1) - ((x2 - (x2 - p.x) - j) * 5 * hd1), 25 * (hd2) - ((y2 - (y2 - p.y) - i) * 5 * hd2));



                        }
                    }
                }
                bg.Graphics.DrawImage(p.w1.pic, 25 * hd1, 25 * hd2);
            
            

            bg.Render();
        }
        public bool victory1,victory11;
       public void endgame() { timer1.Stop(); this.Close();}
 
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game();
drawing(pxmin, pxmax, pymin, pymax);
            

        }


        bool[] down = new bool[4];
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {

                down[0] = true;

            }
            if (e.KeyCode == Keys.S)
            {

                down[1] = true;
            }
            if (e.KeyCode == Keys.A)
            {

                down[2] = true;
            }
            if (e.KeyCode == Keys.D)
            {

                down[3] = true;
            } 
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (timer1.Interval != 75)
                {
                    timer1.Interval = 75;
                   
                }
                else
                { timer1.Interval = 10;  }
            }
            if (e.KeyCode == Keys.Q)
            {
              
                 timer1.Interval = 150; 
            }
            if (e.KeyCode == Keys.Escape)
            {

                item c;
                c = p.w1;
                p.w1 = p.w2;
                p.w2 = c;
               // pictureBox1.Image = p.w1.pic;
            }
            if (e.KeyCode == Keys.N)
            {
                mapload();
                
            }
            if (e.KeyCode == Keys.M)
            {
                m = !m;

            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W)
            {

                down[0] = false;
            }
            if (e.KeyCode == Keys.S)
            {

                down[1] = false;
            }
            if (e.KeyCode == Keys.A)
            {

                down[2] = false;
            }
            if (e.KeyCode == Keys.D)
            {

                down[3] = false;
            }
      
         
      
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
           
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            sizechance();
            bg.Dispose();
            Graphics g = this.CreateGraphics();
            bg = con.Allocate(g, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        { Random r=new Random();
            if (chest1)
            {
                if (chesttype == 0)
                {
                    p.w1 = newitem;
                    
                }
                else
                {
                    p.hp += r.Next(20 * p.level, 50 * p.level);
                    if (p.hp > p.maxhp) { p.hp = p.maxhp; }
                }
                timer1.Start();
            }
            if (exiting1) { if (p.level < 5) { mapload(); } else { victory1 = true; endgame(); } }
            
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label1.Enabled = !label1.Enabled;
            label2.Enabled = !label2.Enabled;
            label3.Enabled = !label3.Enabled;
            chest1 = false;
            exiting1 = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            newitem = null;
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label1.Enabled = !label1.Enabled;
            label2.Enabled = !label2.Enabled;
            label3.Enabled = !label3.Enabled;
            exiting1 = false;
            chest1 = false;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            x2 = x1; y2 = y1;
           
            timeonm = p.w1.timeonm;
            switch (p.w1.type)
            {
                case 1: break;
                case 2: break;
                case 3: break;
            }

        }
        Bitmap[] boss;  
        Bitmap wall ;
        Bitmap mage;
        Bitmap floor;
        Bitmap chest;
        Bitmap[] vrag1;
        Bitmap exit;
        Bitmap exitv;
        public void sizechance() {

            hd1 = this.Width / 50;
            hd2 = this.Height / 50;
            wall = new Bitmap(Properties.Resources.wall, 5 * hd1, 5 * hd2);
            mage = new Bitmap(Properties.Resources.mage, 5 * hd1, 5 * hd2);
            floor = new Bitmap(Properties.Resources.floor, 50 * hd1, 50 * hd2);
            chest = new Bitmap(Properties.Resources.chest, 5 * hd1, 5 * hd2);
            vrag1[0] = new Bitmap(Properties.Resources.vrag1, 5 * hd1, 5 * hd2);
            vrag1[1] = new Bitmap(Properties.Resources.vrag2, 5 * hd1, 5 * hd2);
            vrag1[2] = new Bitmap(Properties.Resources.vrag3, 5 * hd1, 5 * hd2);
            vrag1[3] = new Bitmap(Properties.Resources.vrag4, 5 * hd1, 5 * hd2);
            vrag1[4] = new Bitmap(Properties.Resources.vrag5, 5 * hd1, 5 * hd2);
            exit = new Bitmap(Properties.Resources.stair, 5 * hd1, 5 * hd2);
            exitv = new Bitmap(Properties.Resources.victory, 5 * hd1, 5 * hd2);
            boss[0] = new Bitmap(Properties.Resources.vrag1, 15 * hd1, 15 * hd2);
            boss[1] = new Bitmap(Properties.Resources.vrag2, 15 * hd1, 15 * hd2);
           boss[2] = new Bitmap(Properties.Resources.vrag3, 15 * hd1, 15 * hd2);
            boss[3] = new Bitmap(Properties.Resources.vrag4, 15 * hd1, 15 * hd2);
            boss[4] = new Bitmap(Properties.Resources.vrag5, 15 * hd1, 15 * hd2);

            label1.Font = new System.Drawing.Font("Arial", 1 * hd1, System.Drawing.FontStyle.Bold);
            label2.Font = new System.Drawing.Font("Arial", 1 * hd1, System.Drawing.FontStyle.Bold);
            label3.Font = new System.Drawing.Font("Arial", 2 * hd1, System.Drawing.FontStyle.Bold);
            label1.Left = 20 * hd1;
            label2.Left = 35 * hd1;
            label3.Left = 1 * hd1;
            label1.Top = 30 * hd2;
            label2.Top = 30 * hd2;
            label3.Top = hd2;
            p.w1.ressize(hd1, hd2);
            p.w2.ressize(hd1, hd2);
            progressBar1.Left = 35 * hd1;
            label6.Left = 35 * hd1+progressBar1.Width/4;
          
        }
    }
}

