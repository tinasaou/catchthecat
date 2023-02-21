using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheCat
{
    public partial class Form2: Form
    {

        static int score = 0;
        int x;
        int y;
        Random rand = new Random();
        //List<PictureBox> list = new List<PictureBox>();

        public Form2()
        {

            InitializeComponent();
            timer2.Tick += delegate {
                MessageBox.Show("user scored "+score);
                this.Close();
            };
            timer2.Interval = (int)TimeSpan.FromMinutes(1.5).TotalMilliseconds;
            timer2.Start();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score++;
            if (score == 10)
            {
                timer1.Stop();
                timer1.Interval = 700;
                timer1.Start();
                
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = rand.Next(0, this.Width - pictureBox1.Width);
            y = rand.Next(0, this.Height - pictureBox1.Height);
            this.pictureBox1.Location = new System.Drawing.Point(x, y);
            Console.WriteLine("score = " + score);
            
            
        }

        

        
    }
}