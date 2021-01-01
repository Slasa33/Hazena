namespace DesktopApp
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.prihlasittoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabulkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapasyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraciStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prihlasittoolStripMenuItem1,
            this.tabulkyToolStripMenuItem,
            this.zapasyToolStripMenuItem,
            this.hraciStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(308, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // prihlasittoolStripMenuItem1
            // 
            this.prihlasittoolStripMenuItem1.Name = "prihlasittoolStripMenuItem1";
            this.prihlasittoolStripMenuItem1.Size = new System.Drawing.Size(75, 20);
            this.prihlasittoolStripMenuItem1.Text = "Prihlasit se";
            this.prihlasittoolStripMenuItem1.Click += new System.EventHandler(this.prihlasittoolStripMenuItem1_Click);
            // 
            // tabulkyToolStripMenuItem
            // 
            this.tabulkyToolStripMenuItem.Enabled = false;
            this.tabulkyToolStripMenuItem.Name = "tabulkyToolStripMenuItem";
            this.tabulkyToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.tabulkyToolStripMenuItem.Text = "Tabulky";
            this.tabulkyToolStripMenuItem.Click += new System.EventHandler(this.tabulkyToolStripMenuItem_Click);
            // 
            // zapasyToolStripMenuItem
            // 
            this.zapasyToolStripMenuItem.Enabled = false;
            this.zapasyToolStripMenuItem.Name = "zapasyToolStripMenuItem";
            this.zapasyToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.zapasyToolStripMenuItem.Text = "Zapasy";
            this.zapasyToolStripMenuItem.Click += new System.EventHandler(this.zapasyToolStripMenuItem_Click);
            // 
            // hraciStripMenuItem1
            // 
            this.hraciStripMenuItem1.Enabled = false;
            this.hraciStripMenuItem1.Name = "hraciStripMenuItem1";
            this.hraciStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.hraciStripMenuItem1.Text = "Sprava klubu";
            this.hraciStripMenuItem1.Click += new System.EventHandler(this.hraciStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 132);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem prihlasittoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tabulkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapasyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hraciStripMenuItem1;
    }
}