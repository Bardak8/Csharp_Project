namespace Projet_Purple
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
            this.label1 = new System.Windows.Forms.Label();
            this.Commencer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Commencer
            // 
            this.Commencer.BackColor = System.Drawing.Color.Pink;
            this.Commencer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Commencer.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Commencer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Commencer.Location = new System.Drawing.Point(388, 193);
            this.Commencer.Name = "Commencer";
            this.Commencer.Size = new System.Drawing.Size(194, 79);
            this.Commencer.TabIndex = 1;
            this.Commencer.Text = "Commencer";
            this.Commencer.UseVisualStyleBackColor = false;
            this.Commencer.Click += new System.EventHandler(this.Commencer_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projet_Purple.Properties.Resources.Mateo_crop2;
            this.pictureBox1.Location = new System.Drawing.Point(308, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 79);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 478);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Commencer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button Commencer;
        
        private PictureBox pictureBox1;
    }
}