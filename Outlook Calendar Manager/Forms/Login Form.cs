using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook_Thing.Forms;

namespace Outlook_Calendar_Manager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void LoginButton(object sender, EventArgs e)
        {
            AuthenticationResult authResult = null;
            var accounts = await Program.PublicClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();
                try
                {
                    authResult = await Program.PublicClientApp.AcquireTokenInteractive(Program.Scopes)
                        .WithAccount(accounts.FirstOrDefault())
                        .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                        .ExecuteAsync();
                if (authResult != null) 
                {
                    this.Close();

                }
                }
                catch (MsalException msalex)
                {
                    label1.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
        }
    }
