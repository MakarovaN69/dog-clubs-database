
namespace newKursBd
{
    partial class Help
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
            this.helpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.headerTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helpRichTextBox
            // 
            this.helpRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpRichTextBox.BackColor = System.Drawing.Color.GhostWhite;
            this.helpRichTextBox.Location = new System.Drawing.Point(2, 43);
            this.helpRichTextBox.Name = "helpRichTextBox";
            this.helpRichTextBox.Size = new System.Drawing.Size(932, 405);
            this.helpRichTextBox.TabIndex = 47;
            this.helpRichTextBox.Text = "";
            // 
            // headerTextLabel
            // 
            this.headerTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerTextLabel.Location = new System.Drawing.Point(80, 0);
            this.headerTextLabel.Name = "headerTextLabel";
            this.headerTextLabel.Size = new System.Drawing.Size(776, 40);
            this.headerTextLabel.TabIndex = 48;
            this.headerTextLabel.Text = "Помощь";
            this.headerTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.headerTextLabel);
            this.Controls.Add(this.helpRichTextBox);
            this.Name = "Help";
            this.Text = "Помощь";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox helpRichTextBox;
        private System.Windows.Forms.Label headerTextLabel;
    }
}