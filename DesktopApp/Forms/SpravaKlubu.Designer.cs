namespace DesktopApp.Forms
{
    partial class SpravaKlubu
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
            this.klubView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.klubView)).BeginInit();
            this.SuspendLayout();
            // 
            // klubView
            // 
            this.klubView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.klubView.Location = new System.Drawing.Point(20, 29);
            this.klubView.Name = "klubView";
            this.klubView.Size = new System.Drawing.Size(369, 175);
            this.klubView.TabIndex = 0;
            this.klubView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.klubView_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 73);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vlozit klub";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpravaKlubu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 346);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.klubView);
            this.Name = "SpravaKlubu";
            this.Text = "SpravaKlubu";
            ((System.ComponentModel.ISupportInitialize)(this.klubView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView klubView;
        private System.Windows.Forms.Button button1;
    }
}