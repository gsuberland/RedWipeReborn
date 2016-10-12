using System.Windows.Forms;
using System.Drawing;

namespace RedWipeReborn
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox UserNameTextBox;

        private Label UserNameLabel;

        private Label PasswordLabel;

        private TextBox PasswordTextBox;

        private Button LoginButton;
        
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
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.UserNameTextBox = new TextBox();
            this.UserNameLabel = new Label();
            this.PasswordLabel = new Label();
            this.PasswordTextBox = new TextBox();
            this.LoginButton = new Button();
            base.SuspendLayout();
            this.UserNameTextBox.AcceptsReturn = true;
            this.UserNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.UserNameTextBox.Location = new Point(12, 25);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(374, 20);
            this.UserNameTextBox.TabIndex = 0;
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new Point(12, 9);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(58, 13);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "Username:";
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new Point(12, 48);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            this.PasswordTextBox.AcceptsReturn = true;
            this.PasswordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.PasswordTextBox.Location = new Point(12, 64);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(374, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.LoginButton.Location = new Point(311, 100);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += this.LoginButton_Click;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(398, 135);
            base.Controls.Add(this.LoginButton);
            base.Controls.Add(this.PasswordLabel);
            base.Controls.Add(this.PasswordTextBox);
            base.Controls.Add(this.UserNameLabel);
            base.Controls.Add(this.UserNameTextBox);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "LoginForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RedWipe Reborn";
            base.Load += this.MainForm_Load;
            base.ResumeLayout(false);
            base.PerformLayout();

        }

        #endregion
    }
}