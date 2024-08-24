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
using Microsoft.Graph;
using Azure.Identity;

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
            try
            {
                Program.InitAuth();
                var calendarResult = await Program.PublicGraphClient.Me.Calendars.GetAsync();

                Console.WriteLine(calendarResult);
                calendarResult.ToString();
                foreach (var calendar in calendarResult.Value) 
                {
                    CalendarBox.Items.Add(calendar);
                }
            }
            catch (ServiceException graphex)
            {
            }
        }
        private void LogoutButton(object sender, EventArgs e)
        {

        }
    }
}
