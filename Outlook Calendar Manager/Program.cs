using Microsoft.IdentityModel.Tokens;
using Outlook_Calendar_Manager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Azure.Identity;

namespace Outlook_Calendar_Manager
{
    //thanks to cmastkas.com
    internal static class Program
    {
        public static string CLIENT_ID;
        public static string TENANT_ID;
        public static string[] Scopes = new string[] { "User.Read", "Calendars.Read", "Calendars.ReadWrite", "Calendars.ReadBasic" };

        private static GraphServiceClient graphClient;

        [STAThread]
        static void Main()
        {
            LoadInfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
        public static GraphServiceClient PublicGraphClient { get { return graphClient; } }
        public static void LoadInfo()
        {
            string relPath = "Data/AuthInfo.json";
            string absPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relPath);
            string json = File.ReadAllText(absPath);
            using (JsonDocument jsondoc = JsonDocument.Parse(json)) 
            {
                JsonElement root = jsondoc.RootElement;
                CLIENT_ID = root.GetProperty("clientId").ToString();
                TENANT_ID = root.GetProperty("tenantId").ToString();
            }
        }
        public static void InitAuth()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                ClientId = Program.CLIENT_ID,
                TenantId = Program.TENANT_ID,
                RedirectUri = new Uri("https://login.microsoftonline.com/common/oauth2/nativeclient")
            };
            var interactiveBrowserCredential = new InteractiveBrowserCredential(options);

            graphClient = new GraphServiceClient(interactiveBrowserCredential, Scopes);
        }
    }
}
