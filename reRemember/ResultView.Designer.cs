namespace reRemember
{
    partial class ResultView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textCorrect = new System.Windows.Forms.TextBox();
            this.textIncorrect = new System.Windows.Forms.TextBox();
            this.textPercentage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Correct:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Incorrect:  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Percentage:  ";
            // 
            // textCorrect
            // 
            this.textCorrect.Location = new System.Drawing.Point(125, 12);
            this.textCorrect.Name = "textCorrect";
            this.textCorrect.ReadOnly = true;
            this.textCorrect.Size = new System.Drawing.Size(147, 20);
            this.textCorrect.TabIndex = 3;
            // 
            // textIncorrect
            // 
            this.textIncorrect.Location = new System.Drawing.Point(125, 38);
            this.textIncorrect.Name = "textIncorrect";
            this.textIncorrect.ReadOnly = true;
            this.textIncorrect.Size = new System.Drawing.Size(147, 20);
            this.textIncorrect.TabIndex = 4;
            // 
            // textPercentage
            // 
            this.textPercentage.Location = new System.Drawing.Point(125, 64);
            this.textPercentage.Name = "textPercentage";
            this.textPercentage.ReadOnly = true;
            this.textPercentage.Size = new System.Drawing.Size(147, 20);
            this.textPercentage.TabIndex = 5;
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 98);
            this.Controls.Add(this.textPercentage);
            this.Controls.Add(this.textIncorrect);
            this.Controls.Add(this.textCorrect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultView";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCorrect;
        private System.Windows.Forms.TextBox textIncorrect;
        private System.Windows.Forms.TextBox textPercentage;
    }
}