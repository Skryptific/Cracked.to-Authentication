using Cracked.to_Authentication;
using System;
using System.Windows.Forms;

namespace Cracked.to_Example
{
    public partial class Form1 : Form
    {
        private readonly Auth _auth = new Auth();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var authKey = AuthKeyTextBox.Text;
            var group = GroupTextBox.Text;

            if (string.IsNullOrWhiteSpace(authKey) || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Please check your entries.", this.Text);
                return;
            }

            Global.loginResponse = _auth.Authenticate(authKey, group);

            if (!Global.loginResponse.IsAuthenticated)
            {
                MessageBox.Show("Failed to login.", this.Text);
                return;
            }

            MessageBox.Show("Successfully logged in!", this.Text);

            // Open form or something
        }
    }
}
