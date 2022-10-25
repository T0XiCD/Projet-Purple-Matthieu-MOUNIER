using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace mini_jeux
{
    public partial class Form1 : Form
    {
        
        bool goleft = false;
        bool goright = false;
        bool jumping = false;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 10;
        int verticalspeed = 5;
        int horizontalspeed = 5;
        int hautspeed = 10;







        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Top += jumpSpeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }
            if (goleft)
            {
                player.Left -= 5;
            }
            if (goright)
            {
                player.Left += 5;
            }
            if (jumping)
            {
                jumpSpeed = -15;
                force -= 1; 
            }
            else
            {
                jumpSpeed = 12;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                    x.BringToFront();
                }
                txtScore.Text = "score :" + score;

                if ((string)x.Tag == "coins")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score++;
                    }
                }

               /* if ((string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) )
                    {
                        gameOver();
                    }
                }*/

                if ((string)x.Tag == "portes")
                {
                    
                        if (player.Bounds.IntersectsWith(x.Bounds) && score == 24)
                        {
                            win();
                        }
                    }
                

            }
            enemyOne.Left -= enemyOneSpeed;
            if (enemyOne.Left < pictureBox4.Left || enemyOne.Left + enemyOne.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left -= enemyTwoSpeed;
            if (enemyTwo.Left < pictureBox1.Left || enemyTwo.Left + enemyTwo.Width > pictureBox1.Left + pictureBox1.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }


            verticalPlatform.Top += verticalspeed; 
            if (verticalPlatform.Top < 316 || verticalPlatform.Top > 539)
            {
                verticalspeed = -verticalspeed;
            }

            horizonPlat.Left -= horizontalspeed;
            if (horizonPlat.Left < 70 || horizonPlat.Right > 533)
            {
                horizontalspeed = -horizontalspeed;
            }

            enemyHaut.Left -= hautspeed;
            if (enemyHaut.Left < 34 || enemyHaut.Right > 713)
            {
                hautspeed = -hautspeed;
            }



            if (player.Right > pictureBox36.Left && player.Left < pictureBox36.Right - player.Width / 2 && player.Bottom > pictureBox36.Top) 
            {
                goright = false;
            }

            if (player.Left > pictureBox36.Right && player.Right < pictureBox36.Left - player.Width / 2 && player.Bottom > pictureBox36.Top)
            {
                goleft = false;
            }

            if (player.Right > pictureBox34.Left && player.Left < pictureBox34.Right - player.Width / 2 && player.Bottom > pictureBox34.Top)
            {
                goright = false;
            }

            if (player.Left > pictureBox34.Right && player.Right < pictureBox34.Left - player.Width / 2 && player.Bottom > pictureBox34.Top)
            {
                goleft = false;
            }

        }

        private void gameOver()
        {
            timer1.Stop();
            MessageBox.Show("perdu");

        }

        private void win()
        {
            timer1.Stop();
            MessageBox.Show("gagner");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void porte_Click(object sender, EventArgs e)
        {

        }
    }
}