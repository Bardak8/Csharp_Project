using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Projet_Purple
{
    public partial class Form2 : Form
    {

        int score  = 0;

        bool left = false, right = false;
        bool top = false, down = false;
        PictureBox pic = new PictureBox();
        List<PictureBox> tails = new List<PictureBox>();


        System.Timers.Timer t;
        int h, m, s;
        public Form2()
        {
            InitializeComponent();
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
           
        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
            spawnFood();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
            
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
                for (int i = 1; i < tails.Count; i++)
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
            tail.BackColor = Color.Brown;
            tail.Width = 10;
            tail.Height = 10;
            this.Controls.Add(tail);
            return tail;
        }

        private void spawnFood()
        {
            Random rnd = new Random();
            int rndLocationX = rnd.Next(10, 50);
            int rndLocationY = rnd.Next(10, 50);
            pic.BackColor = Color.Red;
            pic.Height = 10;
            pic.Width = 10;
            this.Controls.Add(pic);
            if (rndLocationX >= 200)
            {
                rndLocationX -= 10;
            }
            if (rndLocationY >= 200)
            {
                rndLocationY -= 10;
            }
            pic.Location = new Point(rndLocationX * 10, rndLocationY * 10);
        }

        private void Keypress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar.ToString() == "a") || (e.KeyChar.ToString() == "A")) && (right == false))
            {
                right = false;
                top = false;
                down = false;
                left = true;
            }
            else if (((e.KeyChar.ToString() == "d") || (e.KeyChar.ToString() == "D")) && (left == false))
            {
                top = false;
                down = false;
                left = false;
                right = true;
            }
            else if (((e.KeyChar.ToString() == "w") || (e.KeyChar.ToString() == "W")) && (down == false))
            {
                down = false;
                left = false;
                right = false;
                top = true;
            }
            else if (((e.KeyChar.ToString() == "s") || (e.KeyChar.ToString() == "S")) && (top == false))
            {
                top = false;
                left = false;
                right = false;
                down = true;
                
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //ticks every 1 sec
            if (pic.Location == head.Location)
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
            Score.Text = Score.ToString();
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
