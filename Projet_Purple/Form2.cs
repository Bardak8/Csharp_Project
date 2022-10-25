using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Projet_Purple
{
    public partial class Form2 : Form
    {

        int score = 0;
        Button Ov_button = new Button();
        Button Ov_button1 = new Button();
        Panel panel = new Panel();
        bool left = false, right = false;
        bool top = false, down = false;

        PictureBox head = new PictureBox();
        PictureBox pic = new PictureBox();
        List<PictureBox> tails = new List<PictureBox>();


        System.Timers.Timer t;
        int h, m, s;
        public Form2()
        {
            InitializeComponent();
            Custom_Timer();
            spawnHead();
            timer1.Stop();
        }

        private void map()
        {
            if (head.Location.X > pictureBox1.Width - head.Width)
            {
                head.Location = new Point(0, head.Location.Y);
            }
            if (head.Location.X < 0)
            {
                head.Location = new Point(pictureBox1.Width - head.Width, head.Location.Y);
            }
            if (head.Location.Y > pictureBox1.Height - head.Height)
            {
                head.Location = new Point(head.Location.X, 0);
            }
            if (head.Location.Y < 0)
            {
                head.Location = new Point(head.Location.X, pictureBox1.Height - head.Height);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {

                s++;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                Timer.Text = String.Format("{0:00}:{1:00}:{2:00}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

            }));
        }

        private void Custom_Timer()
        {
            t = new System.Timers.Timer(1000);
            t.Elapsed += OnTimeEvent;
            t.AutoReset = true;
            t.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spawnFood();
            t.Start();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
            timer1.Stop();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();//Create the new form
            this.Hide();
            f1.Show();//display Form2 to the user;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void sortLocation()
        {
            if (tails.Count == 0)
            {

            }
            else
            {
                for (int i = tails.Count - 1; i > 0; i--)
                {
                    tails[i].Location = tails[i - 1].Location;
                }
                tails[0].Location = head.Location;
            }
        }

        private PictureBox addTails()
        {
            PictureBox tail = new PictureBox();
            tail.Name = "tail" + Score.ToString();
            tail.BackColor = Color.Gold;
            tail.Width = 35;
            tail.Height = 35;
            tail.Location = new Point(0, 0);
            Controls.Add(tail);
            tail.BringToFront();
            return tail;
        }

        private void spawnHead()
        {
            head.Name = "head";
            head.Image = Properties.Resources.Mateo_crop2;
            head.SizeMode = PictureBoxSizeMode.StretchImage;
            head.Width = 35;
            head.Height = 35;
            Controls.Add(head);
            head.Location = new Point(350, 348);
            head.BringToFront();

        }
        private void spawnFood()
        {
            Random rnd = new Random();
            int rndLocationX = rnd.Next(10, pictureBox1.Size.Width / 10);
            int rndLocationY = rnd.Next(10, pictureBox1.Size.Height / 10);
            pic.Image = Properties.Resources.Donuts_PNG_File;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.BackColor = Color.Transparent;
            pic.Height = 35;
            pic.Width = 35;
            Controls.Add(pic);
            if (rndLocationX >= pictureBox1.Size.Width)
            {
                rndLocationX = -10;
            }
            if (rndLocationY >= pictureBox1.Size.Height)
            {
                rndLocationY = -10;
            }
            pic.Location = new Point(rndLocationX * 10, rndLocationY * 10);
            pic.BringToFront();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Keypress(object sender, KeyPressEventArgs e)
        {
            bool cond1 = (tails.Count > 0) && (tails[0]?.Location.X < head.Location.X);
            bool cond2 = (tails.Count > 0) && (tails[0]?.Location.X > head.Location.X);
            bool cond3 = (tails.Count > 0) && (tails[0]?.Location.Y < head.Location.Y);
            bool cond4 = (tails.Count > 0) && (tails[0]?.Location.Y > head.Location.Y);

            if (cond1 & ((e.KeyChar.ToString() == "q") || (e.KeyChar.ToString() == "Q")))
            {
                right = true;
                top = false;
                down = false;
                left = false;
            }
            else if (((e.KeyChar.ToString() == "q") || (e.KeyChar.ToString() == "Q")))
            {
                right = false;
                top = false;
                down = false;
                left = true;
            }
            if (cond2 & ((e.KeyChar.ToString() == "d") || (e.KeyChar.ToString() == "D")))
            {
                right = false;
                top = false;
                down = false;
                left = true;
            }
            else if (((e.KeyChar.ToString() == "d") || (e.KeyChar.ToString() == "D")))
            {
                right = true;
                top = false;
                down = false;
                left = false;
            }
            if (cond3 & ((e.KeyChar.ToString() == "s") || (e.KeyChar.ToString() == "S")))
            {
                right = false;
                top = true;
                down = false;
                left = false;
            }
            else if (((e.KeyChar.ToString() == "s") || (e.KeyChar.ToString() == "SQ")))
            {
                right = false;
                top = false;
                down = true;
                left = false;
            }
            if (cond4 & ((e.KeyChar.ToString() == "z") || (e.KeyChar.ToString() == "Z")))
            {
                right = false;
                top = false;
                down = true;
                left = false;
            }
            else if (((e.KeyChar.ToString() == "z") || (e.KeyChar.ToString() == "ZQ")))
            {
                right = false;
                top = true;
                down = false;
                left = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void eat()
        {
            if (right = true)
            {

            }
        }

        private void Game_Over()
        {
            
            if (tails.Any(tails => tails.Location == head.Location))
            {
                t.Stop();
                timer1.Stop();

                panel.Location = new Point(250, 250);
                panel.Width = 100;
                panel.Height = 50;
                
                Controls.Add(panel);
                panel.Controls.Add(Ov_button);
                panel.Controls.Add(Ov_button1);
                panel.BringToFront();
            }
            
        }
        
        private void Ov_Button_CLick(object sender, EventArgs e) {
            Controls.Remove(panel);
        }
        private void Ov_Button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(panel);
            Form1 f1 = new Form1();//Create the new form
            this.Hide();
            f1.Show();
        }
            private void timer1_Tick(object sender, EventArgs e)
        {
            //ticks every 1 sec
            timer1.Interval = 200;
            map();
            Game_Over();
            Debug.WriteLine(pic.Location);
            Debug.WriteLine(head.Location);
            if (head.Bounds.IntersectsWith(pic.Bounds))
            {
                score++;
                spawnFood();
                tails.Add(addTails());
            }
            sortLocation();
            if (right == true)
            { 
                int r = head.Location.X + head.Height;
                head.Location = new Point(r, head.Location.Y);
            }
            else if (left == true)
            {
                int l = head.Location.X - head.Height;
                head.Location = new Point(l, head.Location.Y);
            }
            else if (top == true)
            {
                int t = head.Location.Y - head.Height;
                head.Location = new Point(head.Location.X, t);
            }
            else if (down == true)
            {
                int d = head.Location.Y + head.Height;  
                head.Location = new Point(head.Location.X, d);
            }
            Score.Text = "Score : " + score;
        }
        
        
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }

      
    }
}
