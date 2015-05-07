namespace reRemember
{
    partial class EditingView
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
            this.formattingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superscriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardBackRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cardFrontRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formattingOptionsToolStripMenuItem,
            this.saveCardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formattingOptionsToolStripMenuItem
            // 
            this.formattingOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.superscriptToolStripMenuItem,
            this.subscriptToolStripMenuItem});
            this.formattingOptionsToolStripMenuItem.Name = "formattingOptionsToolStripMenuItem";
            this.formattingOptionsToolStripMenuItem.Size = new System.Drawing.Size(269, 20);
            this.formattingOptionsToolStripMenuItem.Text = "Formatting Options (Only Affects Back of Card)";
            // 
            // superscriptToolStripMenuItem
            // 
            this.superscriptToolStripMenuItem.Name = "superscriptToolStripMenuItem";
            this.superscriptToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.superscriptToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.superscriptToolStripMenuItem.Text = "Superscript";
            this.superscriptToolStripMenuItem.Click += new System.EventHandler(this.superscriptToolStripMenuItem_Click);
            // 
            // subscriptToolStripMenuItem
            // 
            this.subscriptToolStripMenuItem.Name = "subscriptToolStripMenuItem";
            this.subscriptToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.subscriptToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.subscriptToolStripMenuItem.Text = "Subscript";
            this.subscriptToolStripMenuItem.Click += new System.EventHandler(this.subscriptToolStripMenuItem_Click);
            // 
            // saveCardToolStripMenuItem
            // 
            this.saveCardToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveCardToolStripMenuItem.Name = "saveCardToolStripMenuItem";
            this.saveCardToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveCardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCardToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.saveCardToolStripMenuItem.Text = "Save Card (Ctrl+S)";
            this.saveCardToolStripMenuItem.Click += new System.EventHandler(this.saveCardToolStripMenuItem_Click);
            // 
            // cardBackRichTextBox
            // 
            this.cardBackRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardBackRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.cardBackRichTextBox.Multiline = false;
            this.cardBackRichTextBox.Name = "cardBackRichTextBox";
            this.cardBackRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.cardBackRichTextBox.Size = new System.Drawing.Size(598, 40);
            this.cardBackRichTextBox.TabIndex = 1;
            this.cardBackRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cardBackRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Back of Card";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cardFrontRichTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 63);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Front of Card";
            // 
            // cardFrontRichTextBox
            // 
            this.cardFrontRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardFrontRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.cardFrontRichTextBox.Multiline = false;
            this.cardFrontRichTextBox.Name = "cardFrontRichTextBox";
            this.cardFrontRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.cardFrontRichTextBox.Size = new System.Drawing.Size(598, 40);
            this.cardFrontRichTextBox.TabIndex = 0;
            this.cardFrontRichTextBox.Text = "";
            // 
            // EditingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 169);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "EditingView";
            this.Text = "reRemember - Editing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditingView_FormClosing);
            this.Load += new System.EventHandler(this.EditingView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formattingOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superscriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCardToolStripMenuItem;
        private System.Windows.Forms.RichTextBox cardBackRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox cardFrontRichTextBox;
    }
}