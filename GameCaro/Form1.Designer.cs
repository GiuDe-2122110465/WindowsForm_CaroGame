namespace GameCaro
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
            BanCo = new Panel();
            panel2 = new Panel();
            Avt = new PictureBox();
            panel3 = new Panel();
            BTNLan = new Button();
            tbIP = new TextBox();
            pctrMark = new PictureBox();
            DemNguoc = new ProgressBar();
            tbTenNguoiChoi = new TextBox();
            tmDemNguoc = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            menuToolStripMenuItem1 = new ToolStripMenuItem();
            gameMớiToolStripMenuItem = new ToolStripMenuItem();
            trởToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            menuToolStripMenuItem2 = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avt).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctrMark).BeginInit();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // BanCo
            // 
            BanCo.BackColor = SystemColors.Control;
            BanCo.Location = new Point(12, 32);
            BanCo.Name = "BanCo";
            BanCo.Size = new Size(682, 510);
            BanCo.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(Avt);
            panel2.Location = new Point(801, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 218);
            panel2.TabIndex = 1;
            // 
            // Avt
            // 
            Avt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Avt.BackColor = SystemColors.Control;
            Avt.BackgroundImageLayout = ImageLayout.Stretch;
            Avt.Image = Properties.Resources.XO;
            Avt.Location = new Point(6, 0);
            Avt.Name = "Avt";
            Avt.Size = new Size(308, 212);
            Avt.SizeMode = PictureBoxSizeMode.StretchImage;
            Avt.TabIndex = 0;
            Avt.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(BTNLan);
            panel3.Controls.Add(tbIP);
            panel3.Controls.Add(pctrMark);
            panel3.Controls.Add(DemNguoc);
            panel3.Controls.Add(tbTenNguoiChoi);
            panel3.Location = new Point(801, 269);
            panel3.Name = "panel3";
            panel3.Size = new Size(314, 211);
            panel3.TabIndex = 2;
            // 
            // BTNLan
            // 
            BTNLan.Location = new Point(19, 142);
            BTNLan.Name = "BTNLan";
            BTNLan.Size = new Size(127, 29);
            BTNLan.TabIndex = 4;
            BTNLan.Text = "Kết nối";
            BTNLan.UseVisualStyleBackColor = true;
            BTNLan.Click += BTNLan_Click;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(15, 99);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(131, 27);
            tbIP.TabIndex = 3;
            // 
            // pctrMark
            // 
            pctrMark.BackColor = SystemColors.Control;
            pctrMark.Location = new Point(152, 13);
            pctrMark.Name = "pctrMark";
            pctrMark.Size = new Size(159, 100);
            pctrMark.SizeMode = PictureBoxSizeMode.StretchImage;
            pctrMark.TabIndex = 2;
            pctrMark.TabStop = false;
            // 
            // DemNguoc
            // 
            DemNguoc.Location = new Point(15, 53);
            DemNguoc.Name = "DemNguoc";
            DemNguoc.Size = new Size(131, 29);
            DemNguoc.TabIndex = 1;
            // 
            // tbTenNguoiChoi
            // 
            tbTenNguoiChoi.Location = new Point(15, 13);
            tbTenNguoiChoi.Name = "tbTenNguoiChoi";
            tbTenNguoiChoi.Size = new Size(131, 27);
            tbTenNguoiChoi.TabIndex = 0;
            // 
            // tmDemNguoc
            // 
            tmDemNguoc.Tick += tmDemNguoc_Tick_1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, menuToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 28);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1137, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(14, 24);
            // 
            // menuToolStripMenuItem1
            // 
            menuToolStripMenuItem1.Name = "menuToolStripMenuItem1";
            menuToolStripMenuItem1.Size = new Size(60, 24);
            menuToolStripMenuItem1.Text = "Menu";
            // 
            // gameMớiToolStripMenuItem
            // 
            gameMớiToolStripMenuItem.Name = "gameMớiToolStripMenuItem";
            gameMớiToolStripMenuItem.Size = new Size(32, 19);
            // 
            // trởToolStripMenuItem
            // 
            trởToolStripMenuItem.Name = "trởToolStripMenuItem";
            trởToolStripMenuItem.Size = new Size(32, 19);
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(32, 19);
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem2 });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1137, 28);
            menuStrip2.TabIndex = 4;
            menuStrip2.Text = "menuStrip2";
            // 
            // menuToolStripMenuItem2
            // 
            menuToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem2.Name = "menuToolStripMenuItem2";
            menuToolStripMenuItem2.Size = new Size(60, 24);
            menuToolStripMenuItem2.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(218, 26);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F1;
            quitToolStripMenuItem.Size = new Size(218, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 566);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(BanCo);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Caro don gian";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Avt).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctrMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel BanCo;
        private Panel panel2;
        private Panel panel3;
        private PictureBox Avt;
        private ProgressBar DemNguoc;
        private TextBox tbTenNguoiChoi;
        private Button BTNLan;
        private TextBox tbIP;
        private PictureBox pctrMark;
        private System.Windows.Forms.Timer tmDemNguoc;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem gameMớiToolStripMenuItem;
        private ToolStripMenuItem trởToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem menuToolStripMenuItem1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem menuToolStripMenuItem2;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}
