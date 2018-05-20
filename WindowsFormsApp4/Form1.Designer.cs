namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbScores = new System.Windows.Forms.Label();
            this.tb_Time = new Bunifu.Framework.UI.BunifuTrackbar();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScores
            // 
            this.lbScores.AutoSize = true;
            this.lbScores.BackColor = System.Drawing.Color.Transparent;
            this.lbScores.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScores.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lbScores.Location = new System.Drawing.Point(1344, 9);
            this.lbScores.Name = "lbScores";
            this.lbScores.Size = new System.Drawing.Size(58, 70);
            this.lbScores.TabIndex = 0;
            this.lbScores.Text = "0";
            // 
            // tb_Time
            // 
            this.tb_Time.BackColor = System.Drawing.Color.Black;
            this.tb_Time.BackgroudColor = System.Drawing.Color.White;
            this.tb_Time.BorderRadius = 20;
            this.tb_Time.IndicatorColor = System.Drawing.Color.YellowGreen;
            this.tb_Time.Location = new System.Drawing.Point(443, 23);
            this.tb_Time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Time.MaximumValue = 100;
            this.tb_Time.Name = "tb_Time";
            this.tb_Time.Size = new System.Drawing.Size(550, 41);
            this.tb_Time.SliderRadius = 0;
            this.tb_Time.TabIndex = 1;
            this.tb_Time.Value = 0;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.ErrorImage = global::WindowsFormsApp4.Properties.Resources.button3;
            this.bunifuImageButton2.Image = global::WindowsFormsApp4.Properties.Resources.bt2;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(279, 9);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(97, 70);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 6;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.ErrorImage = global::WindowsFormsApp4.Properties.Resources.button3;
            this.bunifuImageButton1.Image = global::WindowsFormsApp4.Properties.Resources.bt1;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(279, 9);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(97, 70);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 7;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Visible = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.Snow_Forest_Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1414, 569);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.tb_Time);
            this.Controls.Add(this.lbScores);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbScores;
        private Bunifu.Framework.UI.BunifuTrackbar tb_Time;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
    }
}

