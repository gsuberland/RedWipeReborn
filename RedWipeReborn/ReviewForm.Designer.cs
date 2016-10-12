using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RedWipeReborn
{
    partial class ReviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private RichTextBox WarningRichTextBox;

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
            this.WarningRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // WarningRichTextBox
            // 
            this.WarningRichTextBox.BackColor = System.Drawing.Color.Black;
            this.WarningRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WarningRichTextBox.ForeColor = System.Drawing.Color.White;
            this.WarningRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.WarningRichTextBox.Name = "WarningRichTextBox";
            this.WarningRichTextBox.ReadOnly = true;
            this.WarningRichTextBox.Size = new System.Drawing.Size(623, 339);
            this.WarningRichTextBox.TabIndex = 0;
            this.WarningRichTextBox.Text = "{\\rtf1\\ansi\\fontbl\\f0\\fswiss Helvetica;}\\f0\\pard\nThis is some {\\b BOLD} text.\\par" +
    "\n}\n";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 428);
            this.Controls.Add(this.WarningRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReviewForm";
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}