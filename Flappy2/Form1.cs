using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flappy2
{
    public partial class Form1 : Form
    {
        int brzina = 3;
        int gravitacija = 2;
        Random rand = new Random();
        List<PictureBox> prepreke = new List<PictureBox>();
        int brzinaPrepreka = 8;
        int interval = 1200;
        int score = 0;
        bool isGameOver = false;
        Image pipeImage;
        Image birdMidFlap;
        Image birdUpFlap;
        Image birdDownFlap;
        Image gameOverImage;
        int razmak = 150;
        Label scoreLabel = new Label();
        PictureBox gameOverBox = new PictureBox();
        

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true; // nmp sta ovo radi, chatgpt mi rekao da dodam da bi manje kocilo
            ucitajSlike();
            napraviScoreLabel();
            napraviGameOverBox();
            timer1.Start();
            timerPrepreke.Interval = interval;
            timerPrepreke.Tick += new EventHandler(timerPrepreke_Tick);
            timerPrepreke.Start();
        }

        private void ucitajSlike()
        {
            pipeImage = Image.FromFile("pipe-green.png");
            birdMidFlap = Image.FromFile("yellowbird-midflap.png");
            birdUpFlap = Image.FromFile("yellowbird-upflap.png");
            birdDownFlap = Image.FromFile("yellowbird-downflap.png");
            gameOverImage = Image.FromFile("gameover.png");
        }

        private void napraviScoreLabel()
        {
            scoreLabel.Font = new Font("Arial", 16);
            scoreLabel.ForeColor = Color.Black;
            scoreLabel.Location = new Point(10, 10);
            scoreLabel.AutoSize = true;
            scoreLabel.BackColor = Color.Transparent;
            Controls.Add(scoreLabel);
            updateScore();
        }

        private void napraviGameOverBox()
        {
            gameOverBox.SizeMode = PictureBoxSizeMode.AutoSize;
            gameOverBox.Image = gameOverImage;
            gameOverBox.Visible = false;
            gameOverBox.BackColor = Color.Transparent;
            Controls.Add(gameOverBox);
            centriraj();
        }

        private void centriraj()
        {
            gameOverBox.Left = (ClientSize.Width - gameOverBox.Width) / 2;
            gameOverBox.Top = (ClientSize.Height - gameOverBox.Height) / 2;
        }

        private void updateScore()
        {
            scoreLabel.Text = "Score: " + score/4;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            UpdateBirdImage();
            ptica.Top += brzina;
            brzina += gravitacija;
            if (brzina > 6) brzina = 6;

            if (ptica.Bottom > ClientRectangle.Height || ptica.Top < 0)
                GameOver();

            pomerajPrepreke();
            proveriPreklpanje();
        }

        private void UpdateBirdImage()
        {
            if (brzina == 0) ptica.Image = birdMidFlap;
            else if (brzina > 0) ptica.Image = birdUpFlap;
            else ptica.Image = birdDownFlap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (isGameOver)
                    restartuj();
                else
                    brzina = -15;
            }
        }

        private void napraviPrepreku()
        {

            int minVisina = 50;
            int maxVisina = ClientRectangle.Height - 2 * razmak - minVisina;
            int visinaGornje = rand.Next(minVisina, maxVisina);
            int visinaDonje = ClientRectangle.Height - visinaGornje - razmak;

            PictureBox gornjaSipka = napraviPrepreku(visinaGornje, 0);
            PictureBox donjaSipka = napraviPrepreku(visinaDonje, ClientRectangle.Height - visinaDonje);

            prepreke.Add(gornjaSipka);
            prepreke.Add(donjaSipka);
        }

        private PictureBox napraviPrepreku(int height, int top)
        {
            PictureBox pipe = new PictureBox();
            pipe.Size = new Size(50, height);
            pipe.BackColor = Color.Green;
            pipe.SizeMode = PictureBoxSizeMode.StretchImage;
            pipe.Top = top;
            pipe.Left = ClientRectangle.Width;
            pipe.Image = pipeImage;
            Controls.Add(pipe);
            return pipe;
        }

        private void pomerajPrepreke()
        {
            for (int i = prepreke.Count - 1; i >= 0; i--)
            {
                prepreke[i].Left -= brzinaPrepreka;
                if (prepreke[i].Right < 0)
                {
                    Controls.Remove(prepreke[i]);
                    prepreke.RemoveAt(i);
                    score++; // zasto se ovo povecava za 4?
                    updateScore();
                }
            }
        }


        // manje bitno - sve funkcionise

        private void proveriPreklpanje()
        {
            foreach (var p in prepreke)
            {
                if (ptica.Bounds.IntersectsWith(p.Bounds))
                {
                    GameOver();
                    return;
                }
            }
        }

        private void GameOver()
        {
            timer1.Stop();
            timerPrepreke.Stop();
            isGameOver = true;
            gameOverBox.Visible = true;
        }

        private void restartuj()
        {
            brzina = 3;
            score = 0;
            updateScore();
            isGameOver = false;
            ptica.Top = ClientRectangle.Height / 2;
            ptica.Left = ClientRectangle.Width / 4;
            brzina = 0;
            prepreke.Clear();
            Controls.Clear();
            Controls.Add(ptica);
            Controls.Add(scoreLabel);
            Controls.Add(gameOverBox);
            gameOverBox.Visible = false;
            timer1.Start();
            timerPrepreke.Start();
        }

        private void timerPrepreke_Tick(object sender, EventArgs e)
        {
            if (!isGameOver)
            {
                napraviPrepreku();
            }
        }
    }
}
