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
        bool Gamestate  = false;
        bool Gameover = false;
        int score = 0;
        Button Ov_button = new Button();
        Button Ov_button1 = new Button();
        Panel panel = new Panel();      
        bool left = false, right = false;
        bool top = false, down = false;

        Label Game_over_label = new Label();
        PictureBox head = new PictureBox();
        PictureBox pic = new PictureBox();
        List<PictureBox> tails = new List<PictureBox>();


        System.Timers.Timer t;
        int h, m, s;
        public Form2()
        {
            spawnHead();
            InitializeComponent();
            Custom_Timer();
            timer1.Stop();
            t.Stop();
            tails.Clear();
            spawnFood();
        }

        private void map()
        {
            if (right == true && head.Location.X > pictureBox1.Width - head.Width * 1.95)
            {
                Game_Over();
            }
            if (left == true && head.Location.X < pictureBox1.Left + head.Width * 1.6) 
            {
                Game_Over();
            }
            if (down == true && head.Location.Y > pictureBox1.Height - head.Height *2 )
            {
                Game_Over();
            }
            if (top == true && head.Location.Y < pictureBox1.Top + head.Width)
            {
                Game_Over();
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
            if (Gameover == false)
            {
                if (Gamestate == false)
                {
                    t.Start();
                    timer1.Start();
                    Gamestate = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Gameover == false)
            {
                if (Gamestate == true)
                {
                    t.Stop();
                    timer1.Stop();
                    Gamestate = false;
                }
            }
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
            tail.Width = head.Width;
            tail.Height = head.Height;
            Controls.Add(tail);
            tail.BringToFront();
            return tail;
        }

        private void spawnHead()
        {
            head.Name = "head";
            head.Image = Properties.Resources.IMG_20221029_144458 ;
            head.SizeMode = PictureBoxSizeMode.StretchImage;
            head.Width = 35;
            head.Height = 35;
            Controls.Add(head);
            head.Location = new Point(150, 140);
            head.BringToFront();
                
        }
        private void spawnFood()
        {
            Random rnd = new Random();
            int rndLocationX = rnd.Next(30, (int)(pictureBox1.Size.Width * 0.9)) ;
            int rndLocationY = rnd.Next(30, (int)(pictureBox1.Size.Height * 0.9));
            if (rndLocationX > head.Location.X -50 && rndLocationX < head.Location.X  + 50  && rndLocationY > head.Location.Y - 50 && rndLocationY < head.Location.Y + 50)
            {
                spawnFood();
            }
            else
            {
                pic.Image = Properties.Resources.Donuts_PNG_File;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Height = 25;
                pic.Width = 25;
                Controls.Add(pic);
                if (rndLocationX >= pictureBox1.Size.Width)
                {
                    rndLocationX = -10;
                }
                if (rndLocationY >= pictureBox1.Size.Height)
                {
                    rndLocationY = -10;
                }
                pic.Location = new Point(rndLocationX, rndLocationY);
                if (tails.Any(tails => tails.Bounds.IntersectsWith(pic.Bounds))){
                    spawnFood();
                } 
                pic.BringToFront();
            }
        }

     

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Keypress(object sender, KeyPressEventArgs e)
        {
            bool cond1 = (tails.Count > 0) && (tails[0]?.Location.X < head.Location.X);
            bool cond2 = (tails.Count > 0) && (tails[0]?.Location.X > head.Location.X);
            bool cond3 = (tails.Count > 0) && (tails[0]?.Location.Y > head.Location.Y);
            bool cond4 = (tails.Count > 0) && (tails[0]?.Location.Y < head.Location.Y);

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
            else if (((e.KeyChar.ToString() == "s") || (e.KeyChar.ToString() == "S")))
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
            else if (((e.KeyChar.ToString() == "z") || (e.KeyChar.ToString() == "Z")))
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


        private void Game_Over()
        {
            Gameover = true;
            Gamestate = false;
            t.Stop();
            timer1.Stop();

            panel.Location = new Point(250, 120);
            panel.Width = 300;
            panel.Height = 150;


            Controls.Add(panel);
            panel.Controls.Add(Ov_button);
            panel.Controls.Add(Game_over_label);
            Ov_button.Click += Ov_button_CLick;
            panel.Controls.Add(Ov_button1);
            Ov_button1.Click += Ov_button1_Click;
            panel.BringToFront();

            Game_over_label.Width = 150;
            Game_over_label.Text = "GAME OVER";
            Ov_button.BackColor = Color.Green;
            panel.BackColor = Color.Gray;
            panel.BorderStyle = BorderStyle.FixedSingle;
            Ov_button.Text = "Retourner au jeu";
            Ov_button1.BackColor = Color.Blue;
            Ov_button1.Text = "Revenir au menu";
            Game_over_label.Font = new Font("Arial", 14, FontStyle.Bold);
            Game_over_label.ForeColor = Color.Red;
            Ov_button.Width= 100;
            Ov_button.Height = 50;
            Ov_button1.Width = 100;
            Ov_button1.Height = 50;
            Game_over_label.Location = new Point(85, 20);
            Ov_button.Location = new Point(40,60);
            Ov_button1.Location = new Point(170, 60);
            
        }
        


        private void Ov_button_CLick(object sender, EventArgs e) {

            Controls.Remove(panel);
            Close();
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void Score_Click(object sender, EventArgs e)
        {

        }

        private void Ov_button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(panel);
            Form1 f1 = new Form1();//Create the new form
            this.Hide();
            f1.Show();
        }
            private void timer1_Tick(object sender, EventArgs e)
        {
            //ticks every 0.3 sec
            timer1.Interval = 300;
            map();
            if (tails.Any(tails => tails.Location == head.Location))
            {
                Game_Over();
            }
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
