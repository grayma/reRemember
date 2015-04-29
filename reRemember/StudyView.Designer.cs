namespace reRemember
{
    partial class StudyView
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
            System.Windows.Forms.Label labelCard;
            this.buttonFlip = new System.Windows.Forms.Button();
            this.buttonCorrect = new System.Windows.Forms.Button();
            this.buttonIncorrect = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            labelCard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFlip
            // 
            this.buttonFlip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFlip.Location = new System.Drawing.Point(12, 252);
            this.buttonFlip.Name = "buttonFlip";
            this.buttonFlip.Size = new System.Drawing.Size(410, 23);
            this.buttonFlip.TabIndex = 0;
            this.buttonFlip.Text = "&Flip Card";
            this.buttonFlip.UseVisualStyleBackColor = true;
            // 
            // buttonCorrect
            // 
            this.buttonCorrect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCorrect.Location = new System.Drawing.Point(12, 12);
            this.buttonCorrect.Name = "buttonCorrect";
            this.buttonCorrect.Size = new System.Drawing.Size(92, 23);
            this.buttonCorrect.TabIndex = 1;
            this.buttonCorrect.Text = "&Correct";
            this.buttonCorrect.UseVisualStyleBackColor = true;
            // 
            // buttonIncorrect
            // 
            this.buttonIncorrect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIncorrect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncorrect.Location = new System.Drawing.Point(330, 12);
            this.buttonIncorrect.Name = "buttonIncorrect";
            this.buttonIncorrect.Size = new System.Drawing.Size(92, 23);
            this.buttonIncorrect.TabIndex = 2;
            this.buttonIncorrect.Text = "&Incorrect";
            this.buttonIncorrect.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelStatus.Location = new System.Drawing.Point(110, 12);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(214, 23);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCard
            // 
            labelCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelCard.Location = new System.Drawing.Point(9, 38);
            labelCard.Name = "labelCard";
            labelCard.Size = new System.Drawing.Size(413, 211);
            labelCard.TabIndex = 4;
            labelCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Location = new System.Drawing.Point(249, 281);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(173, 23);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "> &Next Card >";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.Location = new System.Drawing.Point(12, 281);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(173, 23);
            this.buttonPrevious.TabIndex = 7;
            this.buttonPrevious.Text = "< &Previous Card <";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            // 
            // buttonFinish
            // 
            this.buttonFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinish.Location = new System.Drawing.Point(191, 281);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(52, 23);
            this.buttonFinish.TabIndex = 8;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            // 
            // StudyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 312);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(labelCard);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonIncorrect);
            this.Controls.Add(this.buttonCorrect);
            this.Controls.Add(this.buttonFlip);
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "StudyView";
            this.Text = "reRemember - Studying";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFlip;
        private System.Windows.Forms.Button buttonCorrect;
        private System.Windows.Forms.Button buttonIncorrect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonFinish;
    }
}