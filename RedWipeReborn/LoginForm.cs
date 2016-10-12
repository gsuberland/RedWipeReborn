using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedWipeReborn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.InitializeComponent();
            this.LoadCredentials();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadCredentials()
        {
            this.UserNameTextBox.Text = SecurePasswordStorage.GetUsername();
            this.PasswordTextBox.Text = SecurePasswordStorage.GetPassword();
        }

        private void DisableControls()
        {
            foreach (Control ctrl in base.Controls)
            {
                ctrl.Enabled = false;
            }
        }

        private void EnableControls()
        {
            foreach (Control ctrl in base.Controls)
            {
                ctrl.Enabled = true;
            }
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.DisableControls();
                    bool flag = await Program.Engine.LoginAsync(this.UserNameTextBox.Text, this.PasswordTextBox.Text);
                    if (!flag)
                    {
                        MessageBox.Show("An error occured while trying to log in. Check your username and password.");
                    }
                    else
                    {
                        this.SaveCredentials();
                        this.MoveNext();
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(string.Format("Unexpected exception: {0}\n{1}\n\nStack Trace:\n{2}", exception.GetType().Name, exception.Message, exception.StackTrace));
                }
            }
            finally
            {
                this.EnableControls();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MoveNext()
        {
            Program.NextForm = new ReviewForm();
            Program.NextForm.MatchCenterFrom(this);
            base.Close();
        }

        private void SaveCredentials()
        {
            SecurePasswordStorage.SaveCredentials(this.UserNameTextBox.Text, this.PasswordTextBox.Text);
        }
    }
}
