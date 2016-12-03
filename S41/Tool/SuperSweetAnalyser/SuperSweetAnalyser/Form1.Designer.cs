namespace SuperSweetAnalyser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.MapImageBox = new System.Windows.Forms.PictureBox();
            this.ResultBoxLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MapImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(12, 12);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(128, 66);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Open File";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // MapImageBox
            // 
            this.MapImageBox.Image = ((System.Drawing.Image)(resources.GetObject("MapImageBox.Image")));
            this.MapImageBox.Location = new System.Drawing.Point(264, 12);
            this.MapImageBox.Name = "MapImageBox";
            this.MapImageBox.Size = new System.Drawing.Size(544, 516);
            this.MapImageBox.TabIndex = 1;
            this.MapImageBox.TabStop = false;
            // 
            // ResultBoxLabel
            // 
            this.ResultBoxLabel.AutoSize = true;
            this.ResultBoxLabel.Location = new System.Drawing.Point(869, 64);
            this.ResultBoxLabel.Name = "ResultBoxLabel";
            this.ResultBoxLabel.Size = new System.Drawing.Size(42, 13);
            this.ResultBoxLabel.TabIndex = 3;
            this.ResultBoxLabel.Text = "Results";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(872, 81);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(237, 140);
            this.ResultTextBox.TabIndex = 4;
            this.ResultTextBox.Text = "Fluffpound used: 0\r\nAnger Issues used: 0\r\nWhipped Cream used: 0\r\nEnergy Drink use" +
    "d: 0\r\nSpicy Chocolate used: 0\r\nSong of Love used: 0\r\nFlower Power used: 0\r\nCooki" +
    "e Jar used: 0\r\nMarble Rain used: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 540);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ResultBoxLabel);
            this.Controls.Add(this.MapImageBox);
            this.Controls.Add(this.OpenFileButton);
            this.Name = "Form1";
            this.Text = "Super Sweet Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.MapImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.PictureBox MapImageBox;
        private System.Windows.Forms.Label ResultBoxLabel;
        private System.Windows.Forms.TextBox ResultTextBox;
    }
}

