namespace Flappy2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ptica = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            krajIgre = new PictureBox();
            timerPrepreke = new System.Windows.Forms.Timer(components);
            pod = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)krajIgre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pod).BeginInit();
            SuspendLayout();
            // 
            // ptica
            // 
            ptica.BackColor = Color.Transparent;
            ptica.Image = (Image)resources.GetObject("ptica.Image");
            ptica.Location = new Point(198, 164);
            ptica.Name = "ptica";
            ptica.Size = new Size(34, 25);
            ptica.TabIndex = 0;
            ptica.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 16;
            timer1.Tick += timer1_Tick;
            // 
            // krajIgre
            // 
            krajIgre.BackColor = Color.Transparent;
            krajIgre.Location = new Point(5, 416);
            krajIgre.Name = "krajIgre";
            krajIgre.Size = new Size(198, 50);
            krajIgre.TabIndex = 1;
            krajIgre.TabStop = false;
            // 
            // timerPrepreke
            // 
            timerPrepreke.Interval = 2000;
            timerPrepreke.Tick += timerPrepreke_Tick;
            // 
            // pod
            // 
            pod.Image = (Image)resources.GetObject("pod.Image");
            pod.Location = new Point(-6, 404);
            pod.Name = "pod";
            pod.Size = new Size(809, 62);
            pod.SizeMode = PictureBoxSizeMode.StretchImage;
            pod.TabIndex = 2;
            pod.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 463);
            Controls.Add(pod);
            Controls.Add(krajIgre);
            Controls.Add(ptica);
            Name = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ptica).EndInit();
            ((System.ComponentModel.ISupportInitialize)krajIgre).EndInit();
            ((System.ComponentModel.ISupportInitialize)pod).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ptica;
        private System.Windows.Forms.Timer timer1;
        private PictureBox krajIgre;
        private System.Windows.Forms.Timer timerPrepreke;
        private PictureBox pod;
    }
}
