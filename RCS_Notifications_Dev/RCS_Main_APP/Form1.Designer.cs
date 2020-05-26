using System.Drawing;

namespace RCS_Main_APP
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnMainAll = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMainControllerAvb = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txCntConnected = new System.Windows.Forms.TextBox();
            this.txMainTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopMonitoring = new System.Windows.Forms.Button();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.btnRobotSupport = new System.Windows.Forms.Button();
            this.btnR4Support = new System.Windows.Forms.Button();
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblRcsMain = new System.Windows.Forms.Label();
            this.pnMainAll.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMainTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMainAll
            // 
            this.pnMainAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMainAll.Controls.Add(this.panel3);
            this.pnMainAll.Controls.Add(this.panel2);
            this.pnMainAll.Controls.Add(this.panel1);
            this.pnMainAll.Controls.Add(this.pnlMainTop);
            this.pnMainAll.Location = new System.Drawing.Point(12, 12);
            this.pnMainAll.Name = "pnMainAll";
            this.pnMainAll.Size = new System.Drawing.Size(981, 501);
            this.pnMainAll.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblMainControllerAvb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 53);
            this.panel3.TabIndex = 12;
            // 
            // lblMainControllerAvb
            // 
            this.lblMainControllerAvb.AutoSize = true;
            this.lblMainControllerAvb.Location = new System.Drawing.Point(402, 16);
            this.lblMainControllerAvb.Name = "lblMainControllerAvb";
            this.lblMainControllerAvb.Size = new System.Drawing.Size(193, 17);
            this.lblMainControllerAvb.TabIndex = 2;
            this.lblMainControllerAvb.Text = "No controllers on the network";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txCntConnected);
            this.panel2.Controls.Add(this.txMainTextBox);
            this.panel2.Location = new System.Drawing.Point(338, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 299);
            this.panel2.TabIndex = 11;
            // 
            // txCntConnected
            // 
            this.txCntConnected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.txCntConnected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txCntConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCntConnected.ForeColor = System.Drawing.Color.Black;
            this.txCntConnected.Location = new System.Drawing.Point(3, -31);
            this.txCntConnected.Multiline = true;
            this.txCntConnected.Name = "txCntConnected";
            this.txCntConnected.Size = new System.Drawing.Size(637, 37);
            this.txCntConnected.TabIndex = 1;
            this.txCntConnected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txMainTextBox
            // 
            this.txMainTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.txMainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txMainTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txMainTextBox.Location = new System.Drawing.Point(3, 42);
            this.txMainTextBox.Multiline = true;
            this.txMainTextBox.Name = "txMainTextBox";
            this.txMainTextBox.ReadOnly = true;
            this.txMainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txMainTextBox.Size = new System.Drawing.Size(637, 257);
            this.txMainTextBox.TabIndex = 0;
            this.txMainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStopMonitoring);
            this.panel1.Controls.Add(this.btnStartMonitoring);
            this.panel1.Controls.Add(this.btnRobotSupport);
            this.panel1.Controls.Add(this.btnR4Support);
            this.panel1.Location = new System.Drawing.Point(4, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 368);
            this.panel1.TabIndex = 9;
            // 
            // btnStopMonitoring
            // 
            this.btnStopMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopMonitoring.BackColor = System.Drawing.Color.Green;
            this.btnStopMonitoring.FlatAppearance.BorderSize = 0;
            this.btnStopMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMonitoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopMonitoring.ForeColor = System.Drawing.Color.Black;
            this.btnStopMonitoring.Location = new System.Drawing.Point(9, 313);
            this.btnStopMonitoring.Name = "btnStopMonitoring";
            this.btnStopMonitoring.Size = new System.Drawing.Size(265, 40);
            this.btnStopMonitoring.TabIndex = 11;
            this.btnStopMonitoring.Text = "Stop - Monitoring is Off";
            this.btnStopMonitoring.UseVisualStyleBackColor = false;
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartMonitoring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartMonitoring.FlatAppearance.BorderSize = 0;
            this.btnStartMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMonitoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMonitoring.ForeColor = System.Drawing.Color.Black;
            this.btnStartMonitoring.Location = new System.Drawing.Point(9, 259);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(265, 40);
            this.btnStartMonitoring.TabIndex = 5;
            this.btnStartMonitoring.Text = "Start - Monitoring is On";
            this.btnStartMonitoring.UseVisualStyleBackColor = false;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click);
            // 
            // btnRobotSupport
            // 
            this.btnRobotSupport.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnRobotSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRobotSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRobotSupport.Location = new System.Drawing.Point(13, 120);
            this.btnRobotSupport.Name = "btnRobotSupport";
            this.btnRobotSupport.Size = new System.Drawing.Size(300, 85);
            this.btnRobotSupport.TabIndex = 9;
            this.btnRobotSupport.Text = "Request Robot Support";
            this.btnRobotSupport.UseVisualStyleBackColor = false;
            this.btnRobotSupport.Click += new System.EventHandler(this.btnRobotSupport_Click);
            // 
            // btnR4Support
            // 
            this.btnR4Support.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnR4Support.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnR4Support.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnR4Support.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnR4Support.Location = new System.Drawing.Point(13, 7);
            this.btnR4Support.Name = "btnR4Support";
            this.btnR4Support.Size = new System.Drawing.Size(300, 85);
            this.btnR4Support.TabIndex = 10;
            this.btnR4Support.Text = "Request R4 Support";
            this.btnR4Support.UseVisualStyleBackColor = false;
            this.btnR4Support.Click += new System.EventHandler(this.btnR4Support_Click);
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainTop.Controls.Add(this.pictureBox1);
            this.pnlMainTop.Controls.Add(this.lblMinimize);
            this.pnlMainTop.Controls.Add(this.lblExit);
            this.pnlMainTop.Controls.Add(this.lblRcsMain);
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(981, 78);
            this.pnlMainTop.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Maroon;
            this.lblMinimize.Location = new System.Drawing.Point(896, -3);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(35, 48);
            this.lblMinimize.TabIndex = 2;
            this.lblMinimize.Text = "-";
            this.lblMinimize.Visible = false;
            this.lblMinimize.Click += new System.EventHandler(this.LblMinimize_Click);
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Maroon;
            this.lblExit.Location = new System.Drawing.Point(937, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(41, 39);
            this.lblExit.TabIndex = 1;
            this.lblExit.Text = "X";
            this.lblExit.Visible = false;
            this.lblExit.Click += new System.EventHandler(this.LblExit_Click);
            // 
            // lblRcsMain
            // 
            this.lblRcsMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRcsMain.AutoSize = true;
            this.lblRcsMain.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRcsMain.ForeColor = System.Drawing.Color.Maroon;
            this.lblRcsMain.Location = new System.Drawing.Point(433, 0);
            this.lblRcsMain.Name = "lblRcsMain";
            this.lblRcsMain.Size = new System.Drawing.Size(113, 62);
            this.lblRcsMain.TabIndex = 0;
            this.lblRcsMain.Text = "RCS";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1005, 525);
            this.Controls.Add(this.pnMainAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RCS Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnMainAll.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlMainTop.ResumeLayout(false);
            this.pnlMainTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMainAll;
        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblRcsMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMainControllerAvb;
        private System.Windows.Forms.Button btnRobotSupport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnR4Support;
        private System.Windows.Forms.Button btnStartMonitoring;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txCntConnected;
        private System.Windows.Forms.TextBox txMainTextBox;
        private System.Windows.Forms.Button btnStopMonitoring;
    }
}

